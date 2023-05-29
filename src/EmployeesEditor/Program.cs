using EmployeesEditor.Commands;
using EmployeesEditor.DataSources.Implementations;
using EmployeesEditor.Model.Implementations;

namespace EmployeesEditor;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var dataSource = new JsonDataSource<Employee>("employees.json");
            var command = Command<Employee>.FromArgs(args, dataSource);
            command.Execute();

            Console.WriteLine(command.Status);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException != null
                ? ex.InnerException.Message
                : ex.Message);
        }
    }
}