using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// response object containing the status of the request
    /// </summary>
    public class ReadDataResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the root directory being returned
        /// </summary>
        public SystemDirectory RootDirectory { get; set; } = new SystemDirectory();
    }
}
