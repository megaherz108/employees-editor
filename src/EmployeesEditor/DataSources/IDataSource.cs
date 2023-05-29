using EmployeesEditor.Model;

namespace EmployeesEditor.DataSources;

public interface IDataSource<T> : IDisposable where T : IEntity
{
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    T GetById(int id);
    IEnumerable<T> GetAll();
    int GenerateId();
    void SaveChanges();
}