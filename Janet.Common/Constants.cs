namespace Janet.Common;

public static class Constants
{
    private static readonly string ProjectsPath = @"D:\Projects";
    private static readonly string ProjectMainFolder = Path.Combine(ProjectsPath, "JanetHomeAi");
    private static readonly string SolutionName = "Janet";
    
    public static readonly string JanetCore = $"{SolutionName}.Core";
    public static readonly string JanetCommon = $"{SolutionName}.Common";
    public static readonly string JanetConsole = $"{SolutionName}.ConsoleApp";
    
    public static readonly string DatabaseName = "JanetCoreLib.sqlite";
    
    public const string ChatBotName = "Janet";
    
    public static class Folders
    {
        public static string Solution = Path.Combine(ProjectMainFolder, SolutionName);
        public static string Secrets = Path.Combine(ProjectMainFolder, "Secrets");
        public static string Database = Path.Combine(ProjectMainFolder, "Database");
        
        public static readonly string JanetCommonPath = Path.Combine(Solution, JanetCommon);
        public static readonly  string JanetCorePath = Path.Combine(Solution, JanetCore);
        public static readonly  string JanetConsolePath = Path.Combine(Solution, JanetConsole);
    }

    public static class Files
    {
        private const string SecretsFile = "secret.json";
        public static readonly string GoogleSecrets = Path.Combine(Folders.Secrets, SecretsFile);
        public static readonly string Database = Path.Combine(Folders.Secrets, DatabaseName);
    }
    
    public static class Data
    {
        public static readonly string DataConnection = $"Data Source={Files.Database}";
    }
    
}