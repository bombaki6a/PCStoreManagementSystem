using SQLite;

namespace PCStoreManagementSystem.Models.Database.Services;
/// <summary>
/// DatabaseAccess thread safe singleton class, used for creating one instance of DatabaseAccess.
/// Check if database exists, if it doesn't, it creates it.
/// </summary>
/// <typeparam name="T">As a type of class with a parametless constructor.</typeparam>
internal sealed class DatabaseAccess<T> where T : new()
{
    private static DatabaseAccess<T> _instance = null;
    private static readonly object padlock = new();

    private static SQLiteAsyncConnection _database;

    public SQLiteAsyncConnection Database { get => _database; }

    private DatabaseAccess()
    {
        Task.Run(async () => await DataInit(default));
    }

    public static async Task DataInit(string databaseName)
    {
        if (_database != null)
        {
            return;
        }

        string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string databasePath = Path.Combine(applicationDataPath, databaseName);
        _database = new SQLiteAsyncConnection(databasePath);
        await _database.CreateTableAsync<T>();
    }

    public static DatabaseAccess<T> Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (padlock)
                {
                    _instance ??= new DatabaseAccess<T>();
                }
            }

            return _instance;
        }
    }
}
