namespace TimeClock.Core.Contracts;

public interface ILiteDBService
{
    void Initialize(string folder);
    Task<Result<IEnumerable<T>>> AllAsync<T>(string name) where T : Model;
    Task<Result<T?>> GetAsync<T>(string name, string id) where T : Model;
    Task<Result> AddAsync<T>(string name, T item) where T : Model;
    Task<Result> UpsertAsync<T>(string name, T item) where T : Model;
    Task<Result> EditAsync<T>(string name, T item) where T : Model;
    Task<Result> DeleteAsync<T>(string name, T item) where T : Model;
}
