using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// item containing the details of the item that was processed
    /// </summary>
    public class ProcessItemResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the file that was created if applicable
        /// </summary>
        public DirectoryFile? FileCreated { get; set; } = null;

        /// <summary>
        /// the directory that was created if applicable
        /// </summary>
        public SystemDirectory? DirectoryCreated { get; set; } = null;
    }
}
