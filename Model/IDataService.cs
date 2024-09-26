namespace Model;

public interface IDataService<TClass>
    where TClass : class
{
    public Task<TClass?> GetByIdAsync(string id);
    public Task<IEnumerable<TClass>> GetAllAsync();
    public Task<bool> CreateAsync(TClass entity);
    public Task<bool> UpdateAsync(TClass entity);
    public Task<bool> DeleteAsync(string id);
}