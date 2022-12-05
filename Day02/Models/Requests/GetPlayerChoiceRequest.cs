using Day02.Models.Enums;

namespace Day02.Models.Requests
{
    /// <summary>
    /// request for getting the players choice
    /// </summary>
    public class GetPlayerChoiceRequest
    {
        /// <summary>
        /// the choice the opponent made
        /// </summary>
        public ChoiceEnum OpponentChoice { get; set; } = ChoiceEnum.None;

        /// <summary>
        /// the instruction on whether you should win/lose/draw
        /// </summary>
        public string VictoryCommand { get; set; } = string.Empty;
    }
}
