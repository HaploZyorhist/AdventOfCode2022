using Day02.Models.Enums;

namespace Day02.Models.Responses
{
    /// <summary>
    /// response object containing data on the respoinse of the request
    /// </summary>
    public class PlayerPointResponse
    {
        /// <summary>
        /// status of the request
        /// default to failure
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// points the player earned
        /// default to 0
        /// </summary>
        public int PlayerPoints { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int OpponentPoints { get; set; } = 0;
    }
}
