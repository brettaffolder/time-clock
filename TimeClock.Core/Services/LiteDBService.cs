using LiteDB;

using TimeClock.Core.Contracts;

namespace TimeClock.Core.Services;

public class LiteDBService : ILiteDBService
{
    private string? _folder;

    public void Initialize(string folder)
    {
        _folder = folder;
    }

    public async Task<Result<IEnumerable<T>>> AllAsync<T>(string name) where T : Model
    {
        return await Task.Run<Result<IEnumerable<T>>>(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");
            if (!File.Exists(file))
            {
                return new List<T>();
            }

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=true");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                IEnumerable<T> items = table.FindAll();

                return items.ToList();
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }

    public async Task<Result<T?>> GetAsync<T>(string name, string id) where T : Model
    {
        return await Task.Run<Result<T?>>(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");
            if (!File.Exists(file))
            {
                return null;
            }

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=true");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                T? item = table.FindOne(x => x.Id == id);

                return item;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }

    public async Task<Result> AddAsync<T>(string name, T item) where T : Model
    {
        return await Task.Run(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=false");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                _ = table.Insert(item);

                return Result.Success;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }

    public async Task<Result> UpsertAsync<T>(string name, T item) where T : Model
    {
        return await Task.Run(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=false");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                _ = table.Upsert(item);

                return Result.Success;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }

    public async Task<Result> EditAsync<T>(string name, T item) where T : Model
    {
        return await Task.Run(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=false");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                _ = table.Update(item);

                return Result.Success;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }

    public async Task<Result> DeleteAsync<T>(string name, T item) where T : Model
    {
        return await Task.Run(() =>
        {
            if (string.IsNullOrWhiteSpace(_folder))
            {
                return new Error("LiteDB service not initialized.");
            }

            string file = Path.Combine(_folder, $"{name}.db");

            try
            {
                using var db = new LiteDatabase($"Filename={file};Connection=shared;ReadOnly=false");
                ILiteCollection<T> table = db.GetCollection<T>(name);
                _ = table.Delete(item.Id);

                return Result.Success;
            }
            catch (Exception ex)
            {
                return new Error(ex.Message);
            }
        });
    }
}
