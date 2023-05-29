using EmployeesEditor.DataSources;
using EmployeesEditor.Model;
using EmployeesEditor.Model.Implementations;

namespace EmployeesEditor.Tests.Fakes;

internal class FakeDataSource<T> : IDataSource<T> where T : IEntity
{
    private readonly List<T> _data = new();

    internal FakeDataSource()
    {
        //_data.Add(
        //    new Employee
        //    {
        //        Id = 1,
        //        FirstName = "John",
        //        LastName = "Doe",
        //        SalaryPerHour = 12.3m
        //    }
        //);
    }

    public void Add(T item)
    {
        _data.Add(item);
    }

    public void Update(T item)
    {
        T currentItem = _data.First(i => i.Id == item.Id);
        int index = _data.IndexOf(currentItem);
        _data[index] = item;
    }

    public void Delete(T item)
    {
        _data.Remove(item);
    }

    public T GetById(int id)
    {
        return _data.FirstOrDefault(e => e.Id == id)
               ?? throw new ArgumentException($"Item with Id='{id}' is not found.");
    }

    public IEnumerable<T> GetAll()
    {
        return _data;
    }

    public int GenerateId()
    {
        return _data.Count == 0 ? 1 : _data.Select(e => e.Id).Max() + 1;
    }

    public void SaveChanges()
    {
    }

    public void Dispose()
    {
    }
}