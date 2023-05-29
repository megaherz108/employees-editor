using EmployeesEditor.Common;
using EmployeesEditor.DataSources;
using EmployeesEditor.Model;

namespace EmployeesEditor.Commands.Implementations;

internal class GetAllCommand<T> : Command<T> where T : IEntity, new()
{
    public GetAllCommand(string[] args, IDataSource<T> ds) : base(args, ds)
    {
        AllowedParameters = GetAllowedParameters(ParametersType.None);
    }

    public override void Execute()
    {
        GetAllItems();
    }

    private void GetAllItems()
    {
        Status = "Items found:" + Environment.NewLine;
        foreach (T item in DataSource.GetAll())
        {
            Status += item + Environment.NewLine;
        }
    }
}