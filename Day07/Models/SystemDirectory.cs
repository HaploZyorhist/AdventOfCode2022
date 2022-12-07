namespace Day07.Models
{
    /// <summary>
    /// directory object containing directories and files
    /// </summary>
    public class SystemDirectory
    {
        /// <summary>
        /// the name of the directory
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// the name of the parent directory
        /// </summary>
        public SystemDirectory? ParentDirectory { get; set; } = null;

        /// <summary>
        /// list of child directories
        /// </summary>
        public List<SystemDirectory> ChildDirectories { get; set; } = new List<SystemDirectory>();

        /// <summary>
        /// list of child files
        /// </summary>
        public List<DirectoryFile> ChildFiles { get; set; } = new List<DirectoryFile>();

        /// <summary>
        /// method for getting total directory size
        /// </summary>
        /// <returns>the total size for the directory</returns>
        public async Task<int> GetDirectorySize()
        {
            try
            {
                int totalSize = 0;

                totalSize += ChildFiles.Sum(x => x.Size);

                ChildDirectories.ForEach(async x => totalSize += await x.GetDirectorySize());

                return totalSize;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not get directory size for Directory {Name}\r\n{ex.Message}");
                return 0;
            }
        }
    }
}
