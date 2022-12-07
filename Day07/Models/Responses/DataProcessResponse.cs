using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object for returning processed data and status of request
    /// </summary>
    public class DataProcessResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the root directory containing all other directories and files
        /// </summary>
        public SystemDirectory RootDirectory { get; set; } = new SystemDirectory();
    }
}
