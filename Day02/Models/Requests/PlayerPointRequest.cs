namespace Day02.Models.Requests
{
    /// <summary>
    /// request for getting players points based on their choice
    /// </summary>
    public class PlayerPointRequest
    {
        /// <summary>
        /// the game object being calculated
        /// </summary>
        public GameObject GameChoices { get; set; } = new GameObject();
    }
}
