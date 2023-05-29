using System.ComponentModel.DataAnnotations;

namespace EmployeesEditor.Model.Implementations;

public class Employee : IEntity
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private decimal _salaryPerHour;


    public int Id { get; init; }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("First name should not be empty.");

            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("Last name should not be empty.");

            _lastName = value;
        }
    }

    public decimal SalaryPerHour
    {
        get => _salaryPerHour;
        set
        {
            if (value < 0)
                throw new ValidationException("Salary should be bigger than 0.");

            _salaryPerHour = value;
        }
    }


    public override string ToString()
    {
        return $"Id={Id}, FirstName={FirstName}, LastName={LastName}, Salary={SalaryPerHour}";
    }
}