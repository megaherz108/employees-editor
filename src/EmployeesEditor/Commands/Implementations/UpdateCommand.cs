using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands.Implementations;

internal class UpdateCommand<T> : Command<T> where T : IEntity, new()
{
    public UpdateCommand(string[] args, IDataSource<T> ds) : base(args, ds)
    {
        AllowedParameters = GetAllowedParameters(ParametersType.All);
    }

    public override void Execute()
    {
        UpdateItem();
    }

    private void UpdateItem()
    {
        T item = DataSource.GetById(Convert.ToInt32(Parameters["Id"]));
        item.SetProperties(Parameters);
        DataSource.Update(item);

        SaveChanges();

        Status = $"{typeof(T).Name} is updated: {item}";
    }
}