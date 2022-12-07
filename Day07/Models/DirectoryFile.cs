namespace Day07.Models
{
    /// <summary>
    /// object containing file name and size
    /// </summary>
    public class DirectoryFile
    {
        /// <summary>
        /// the name of the file
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// the size of the file
        /// </summary>
        public int Size { get; set; } = 0;
    }
}
