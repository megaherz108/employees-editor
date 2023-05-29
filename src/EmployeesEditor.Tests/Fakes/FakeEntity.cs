using EmployeesEditor.Model;

namespace EmployeesEditor.Tests.Fakes;

internal class FakeEntity : IEntity
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public decimal Salary { get; init; }

    public override string ToString()
    {
        return $"Id={Id}, Name={Name}, Salary={Salary}";
    }
}