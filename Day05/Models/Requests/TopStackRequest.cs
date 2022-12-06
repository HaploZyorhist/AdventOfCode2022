namespace Day05.Models.Requests
{
    /// <summary>
    /// object containing the data in relation to the configuration of the ship
    /// </summary>
    public class TopStackRequest
    {
        /// <summary>
        /// the configuration of the ship
        /// part 1
        /// </summary>
        public List<Stack<string>> CargoStacks { get; set; } = new List<Stack<string>>();

        /// <summary>
        /// the cargo stacks and their contents
        /// part 2
        /// </summary>
        public List<Stack<string>> CargoStacksRevised { get; set; } = new List<Stack<string>>();
    }
}
