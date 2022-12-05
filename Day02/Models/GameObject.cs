using Day02.Models.Enums;

namespace Day02.Models
{
    /// <summary>
    /// object for containing what the players chose for the game
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// an indicator on what the player chose
        /// </summary>
        public ChoiceEnum PlayerChoice { get; set; } = ChoiceEnum.None;

        /// <summary>
        /// an indicator of what the opponent chose
        /// </summary>
        public ChoiceEnum OpponentChoice { get; set; } = ChoiceEnum.None;

    }
}
