using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object containing directories over the size requested
    /// </summary>
    public class GetLargeDirectoryResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the list of directories under the set value
        /// </summary>
        public List<SystemDirectory> LargeDirectories { get; set; } = new List<SystemDirectory>();
    }
}
