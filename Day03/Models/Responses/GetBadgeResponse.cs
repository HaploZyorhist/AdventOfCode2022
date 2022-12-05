using Day03.Models.Enums;

namespace Day03.Models.Responses
{
    /// <summary>
    /// object containing badge items from the ruck sacks
    /// </summary>
    public class GetBadgeResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the badge items that are returned
        /// </summary>
        public List<char> Badges { get; set; } = new List<char>();
    }
}
