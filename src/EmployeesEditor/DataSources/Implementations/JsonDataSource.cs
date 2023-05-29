using System.Text.Json;
using EmployeesEditor.Common;
using EmployeesEditor.Model;

namespace EmployeesEditor.DataSources.Implementations;

internal class JsonDataSource<T> : IDataSource<T> where T : IEntity
{
    private readonly IList<T> _data;

    public JsonDataSource(string file)
    {
        // TODO: Init FileStream
        _data = Read(file);
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

    private IList<T> Read(string file)
    {
        // TODO: Create default JSON file?
        string json = File.ReadAllText(file);
        // TODO: Add error handling
        var result = JsonSerializer.Deserialize<List<T>>(json);

        if (result == null)
            throw new InvalidDataException("Invalid data.");

        return result;
    }

    public void SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string resultJson = JsonSerializer.Serialize(_data, options);
        File.WriteAllText(Constants.DATA_PATH, resultJson);
    }

    public void Dispose()
    {
        // TODO: Close FileStream
        throw new NotImplementedException();
    }
}