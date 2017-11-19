using System;
using System.IO;

namespace FileSearchr
{
    public class FileSearchConfig
    {
        private static readonly Lazy<FileSearchConfig> lazy =
            new Lazy<FileSearchConfig>(() => new FileSearchConfig());

        public static FileSearchConfig Instance => lazy.Value;

        private FileSearchConfig()
        {
        }

        public string[] IgnoreFolders { get; set; } = { "bin", "obj", ".vs", "packages" };
        public string[] IgnoreFiles { get; set; } = { ".dll", ".pdb", ".csproj", ".sln", "Designer.cs", ".resx", "app.config", "packages.config", "App.xaml.cs" };
        public string[] DeleteFolders { get; set; } = { "bin", "obj", "Testbed" };
        public string[] DeleteFiles { get; set; } = { };

        public string SearchDir = AppDomain.CurrentDomain.BaseDirectory;
        public string SaveFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
        public DateTime CompareTime = DateTime.Parse("2017-08-08");
        public IComponentWriter Writer = new ResultTextWriter();
    }
}