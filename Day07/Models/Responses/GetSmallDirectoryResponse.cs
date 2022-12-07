using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object containing the data from getting small directories
    /// </summary>
    public class GetSmallDirectoryResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the list of directories under the set value
        /// </summary>
        public List<SystemDirectory> SmallDirectories { get; set; } = new List<SystemDirectory>();
    }
}
