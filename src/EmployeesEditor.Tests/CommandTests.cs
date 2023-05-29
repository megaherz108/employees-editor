using EmployeesEditor.Commands;
using EmployeesEditor.DataSources;
using EmployeesEditor.Tests.Fakes;

namespace EmployeesEditor.Tests;

public class CommandTests
{
    [Fact]
    public void GetCommand_GetsInfo()
    {
        // Arrange
        const int id = 1;
        IDataSource <FakeEntity> ds = new FakeDataSource<FakeEntity>();
        var fakeData = new FakeEntity
        {
            Id = id,
            Name = "John Doe",
            Salary = 12.3m
        };
        ds.Add(fakeData);

        var args = new[] { "-get", $"Id: {id}" };
        var command = Command<FakeEntity>.FromArgs(args, ds);
        
        // Act
        command.Execute();

        // Assert
        Assert.Equal($"{nameof(FakeEntity)} info: {fakeData}", command.Status);
    }

    [Fact]
    public void AddCommand_AddsRecord()
    {
        // Arrange
        IDataSource<FakeEntity> ds = new FakeDataSource<FakeEntity>();
        var args = new[] { "-add",  "Name:John Doe", "Salary:12.3" };
        var command = Command<FakeEntity>.FromArgs(args, ds);

        // Act
        command.Execute();

        // Assert
        Assert.Single(ds.GetAll());
        var record = ds.GetById(1);
        Assert.Equal(1, record.Id);
        Assert.Equal("John Doe", record.Name);
        Assert.Equal(12.3m, record.Salary);

        // TODO: Check status
    }
}