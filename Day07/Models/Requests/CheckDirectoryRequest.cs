namespace Day07.Models.Requests
{
    /// <summary>
    /// object for checking directories for size
    /// </summary>
    public class CheckDirectoryRequest
    {
        /// <summary>
        /// the directory to be checked
        /// </summary>
        public SystemDirectory Directory { get; set; } = new SystemDirectory();
    }
}
