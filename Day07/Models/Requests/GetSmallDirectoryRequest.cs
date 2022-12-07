namespace Day07.Models.Requests
{
    /// <summary>
    /// request for getting small directories
    /// </summary>
    public class GetSmallDirectoryRequest
    {
        /// <summary>
        /// the root directory that is being processed for data
        /// </summary>
        public SystemDirectory RootDirectory { get; set; } = new SystemDirectory();
    }
}
