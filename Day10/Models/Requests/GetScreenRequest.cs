namespace Day10.Models.Requests
{
    /// <summary>
    /// the object containing data to be processed for screen display
    /// </summary>
    public class GetScreenRequest
    {
        /// <summary>
        /// the instructions that are to be processed
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}
