using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object containing the details on the check of directories
    /// </summary>
    public class CheckDirectoryResponsee
    {
        /// <summary>
        /// object for showing the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// directories that are within the dictated threshold
        /// </summary>
        public List<SystemDirectory> SmallDirectories { get; set; } = new List<SystemDirectory>();
    }
}
