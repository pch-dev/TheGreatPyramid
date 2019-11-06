using System;
using System.IO;
using TheGreatPyramid.Configuration;

namespace TheGreatPyramid.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string inputPath;

        public FileRepository(FileRepositoryConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (string.IsNullOrEmpty(configuration.BasePath))
            {
                throw new ArgumentNullException(nameof(configuration.BasePath));
            }

            if (string.IsNullOrEmpty(configuration.InputPath))
            {
                throw new ArgumentNullException(nameof(configuration.InputPath));
            }

            inputPath = Path.Combine(configuration.BasePath, configuration.InputPath);
        }

        public string[] Read()
        {
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException($"Could not locate file in path {inputPath}");
            }

            var lines = File.ReadAllLines(inputPath);

            return lines;
        }
    }
}
