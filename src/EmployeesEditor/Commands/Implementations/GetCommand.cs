using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands.Implementations;

internal class GetCommand<T> : Command<T> where T : IEntity, new()
{
    public GetCommand(string[] args, IDataSource<T> ds) : base(args, ds)
    {
        AllowedParameters = GetAllowedParameters(ParametersType.Id);
    }

    public override void Execute()
    {
        GetItem();
    }

    private void GetItem()
    {
        T item = DataSource.GetById(Convert.ToInt32(Parameters["Id"]));
        Status = $"{typeof(T).Name} info: {item}";
    }
}