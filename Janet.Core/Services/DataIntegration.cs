using System.Data.SQLite;
using Janet.Common;

namespace Janet.Core.Services;

public static class DataIntegration
{
    private static readonly string ConnectionString = $"Data Source={Constants.Files.Database};Version=3;";

    public static void Initialize()
    {
        if (!File.Exists(Constants.Files.Database))
        {
            SQLiteConnection.CreateFile(Constants.Folders.Database);
        }

        EnsureTableExists();
    }
    
    private static readonly List<string> DataTables =
    [
        "Conversations",
        "Messages",
        "UserProfiles",
        "ChatCompletion" 
    ];

    private static void EnsureTableExists()
    {
        foreach (var tbl in DataTables.Where(p_tbl => !DoesTableExist(p_tbl)))
        {
            CreateTable(tbl);
        }
    }
    
    private static void CreateTable(string p_tableName)
    {
        var sqlFile = Path.Combine(Constants.Folders.SqlScripts, $"{p_tableName}.sql");
        if(!File.Exists(sqlFile)) return;
        var sql = File.ReadAllText(sqlFile);
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        using var command = new SQLiteCommand(connection);
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
    private static bool DoesTableExist(string p_tableName)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        // ReSharper disable once ConvertToConstant.Local
        var tableCheck = "SELECT name FROM sqlite_master WHERE type='table' AND name='{p_tableName}';";
        using var command = new SQLiteCommand(tableCheck, connection);
        var result = command.ExecuteScalar();
        return result != null;
    }
}