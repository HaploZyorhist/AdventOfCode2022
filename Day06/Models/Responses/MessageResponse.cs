using Day06.Models.Enums;

namespace Day06.Models.Responses
{
    /// <summary>
    /// object containing the status and location of the message request
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the position of the marker
        /// </summary>
        public int MessagePosition { get; set; } = 0;
    }
}
