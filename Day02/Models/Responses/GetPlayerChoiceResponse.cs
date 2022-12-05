using Day02.Models.Enums;

namespace Day02.Models.Responses
{
    /// <summary>
    /// response object dictating what the player should choose
    /// </summary>
    public class GetPlayerChoiceResponse
    {
        /// <summary>
        /// the choice the player should make
        /// </summary>
        public ChoiceEnum Choice { get; set; } = ChoiceEnum.None;

        /// <summary>
        /// the status of the request
        /// default to failure
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;
    }
}
