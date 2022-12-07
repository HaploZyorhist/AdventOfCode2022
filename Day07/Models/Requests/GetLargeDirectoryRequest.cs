namespace Day07.Models.Requests
{
    /// <summary>
    /// object for requesting large directories
    /// </summary>
    public class GetLargeDirectoryRequest
    {
        /// <summary>
        /// the root directory that is being processed for data
        /// </summary>
        public SystemDirectory RootDirectory { get; set; } = new SystemDirectory();
    }
}
