namespace Day07.Models.Requests
{
    /// <summary>
    /// object for requesting directories over a certain size
    /// </summary>
    public class CheckAndFilterDirectoryRequest
    {
        /// <summary>
        /// the directory to be checked
        /// </summary>
        public SystemDirectory Directory { get; set; } = new SystemDirectory();
    }
}
