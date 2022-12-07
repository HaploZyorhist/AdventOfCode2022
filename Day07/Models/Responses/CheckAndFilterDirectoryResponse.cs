using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object containing status of the request and directories over the requirement
    /// </summary>
    internal class CheckAndFilterDirectoryResponse
    {
        /// <summary>
        /// object for showing the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// directories that are within the dictated threshold
        /// </summary>
        public List<SystemDirectory> LargeDirectories { get; set; } = new List<SystemDirectory>();
    }
}
