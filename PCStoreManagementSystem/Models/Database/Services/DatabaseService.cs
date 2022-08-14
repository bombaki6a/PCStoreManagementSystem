namespace PCStoreManagementSystem.Models.Database.Services;

/// <summary>
/// Generic static class, used for inserting, deleting and modifying data from the Database.
/// </summary>
/// <typeparam name="T">As a Type of class with a parametless constructor.</typeparam>
public static class DatabaseService<T> where T : new()
{
    private const string databaseName = "AppDatabase.db";
    private static readonly DatabaseAccess<T> _access = DatabaseAccess<T>.Instance;

    public static async Task AddColumnAsync(T colunm)
    {
        await DatabaseAccess<T>.DataInit(databaseName);
        await _access.Database.InsertAsync(colunm);
    }

    public static async Task RemoveColumnAsync(int id)
    {
        await DatabaseAccess<T>.DataInit(databaseName);
        await _access.Database.DeleteAsync<T>(id);
    }

    // This will be removed
    public static async Task DropTableAsync()
    {
        await DatabaseAccess<T>.DataInit(databaseName);
        await _access.Database.DropTableAsync<T>();
    }

    public static async Task UpdateColumnAsync(T column)
    {
        await DatabaseAccess<T>.DataInit(databaseName);
        await _access.Database.UpdateAsync(column);
    }

    public static async Task<List<T>> GetTableAsync()
    {
        await DatabaseAccess<T>.DataInit(databaseName);

        List<T> table = await _access.Database.Table<T>().ToListAsync();
        return table;
    }
}
