using Day05.Models.Enums;

namespace Day05.Models.Responses
{
    /// <summary>
    /// object containing the results of the ship configuration request
    /// </summary>
    public class ShipConfigurationResponse
    {
        /// <summary>
        /// the status of the ship configuration request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the cargo stacks and their contents
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
