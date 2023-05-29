using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands.Implementations;

internal class AddCommand<T> : Command<T> where T : IEntity, new()
{
    public AddCommand(string[] args, IDataSource<T> ds) : base(args, ds)
    {
        AllowedParameters = GetAllowedParameters(ParametersType.NonId);
    }

    public override void Execute()
    {
        AddItem();
    }

    private void AddItem()
    {
        T item = new()
        {
            Id = DataSource.GenerateId()
        };

        item.SetProperties(Parameters);
        DataSource.Add(item);

        SaveChanges();

        Status = $"{typeof(T).Name} is added: {item}";
    }
}