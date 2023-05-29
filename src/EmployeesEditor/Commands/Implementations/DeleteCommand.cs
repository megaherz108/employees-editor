using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands.Implementations;

internal class DeleteCommand<T> : Command<T> where T : IEntity, new()
{
    public DeleteCommand(string[] args, IDataSource<T> dataSource) : base(args, dataSource)
    {
        AllowedParameters = GetAllowedParameters(ParametersType.Id);
    }

    public override void Execute()
    {
        DeleteItem();
    }

    private void DeleteItem()
    {
        T item = DataSource.GetById(Convert.ToInt32(Parameters["Id"]));
        DataSource.Delete(item);

        SaveChanges();

        Status = $"{typeof(T).Name} is deleted: {item}";
    }
}