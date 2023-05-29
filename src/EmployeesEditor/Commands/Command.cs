using EmployeesEditor.Commands.Implementations;
using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands;

public abstract class Command<T> where T : IEntity, new()
{
    protected readonly IDataSource<T> DataSource;


    protected Command(string[] args, IDataSource<T> ds)
    {
        InitParameters(args);
        DataSource = ds;
    }


    public string Status { get; protected set; } = string.Empty;

    protected List<string> AllowedParameters { get; init; } = new();

    protected Dictionary<string, string> Parameters { get; } = new();


    public abstract void Execute();

    public static Command<T> FromArgs(string[] args, IDataSource<T> ds)
    {
        string commandArg = args[0];

        Command<T> command = commandArg switch
        {
            Constants.COMMAND_ADD => new AddCommand<T>(args, ds),
            Constants.COMMAND_UPDATE => new UpdateCommand<T>(args, ds),
            Constants.COMMAND_DELETE => new DeleteCommand<T>(args, ds),
            Constants.COMMAND_GET => new GetCommand<T>(args, ds),
            Constants.COMMAND_GET_ALL => new GetAllCommand<T>(args, ds),
            _ => throw new NotSupportedException($"Command '{commandArg}' is not supported.")
        };

        command.ValidateParameters();

        return command;
    }
    
    protected void SaveChanges()
    {
        DataSource.SaveChanges();
    }

    protected void ValidateParameters()
    {
        foreach (var parameter in Parameters)
        {
            if (!AllowedParameters.Contains(parameter.Key))
                throw new ArgumentException($"Parameter '{parameter.Key}' is not allowed for this command.");
        }
    }

    protected static List<string> GetAllowedParameters(ParametersType parametersType)
    {
        var allowedParameters = new List<string>();

        var entityType = typeof(T);
        var properties = entityType.GetProperties();

        switch (parametersType)
        {
            case ParametersType.None:
                break;

            case ParametersType.All:
                var propertyNames = properties.Select(p => p.Name);
                allowedParameters.AddRange(propertyNames);
                break;

            case ParametersType.Id:
                allowedParameters.Add("Id");
                break;

            case ParametersType.NonId:
                var nonIdPropertyNames = properties.Where(p => p.Name != "Id").Select(p => p.Name);
                allowedParameters.AddRange(nonIdPropertyNames);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(parametersType), parametersType, "Unknown parameters type.");
        }

        return allowedParameters;
    }

    private void InitParameters(string[] args)
    {
        foreach (string parameter in args.Skip(1))
        {
            string key = parameter.Split(":")[0];
            string value = parameter.Split(":")[1];
            Parameters.Add(key, value);
        }
    }
}