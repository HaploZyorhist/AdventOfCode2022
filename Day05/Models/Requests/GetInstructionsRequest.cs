namespace Day05.Models.Requests
{
    /// <summary>
    /// object containing data to be processed for getting instructions
    /// </summary>
    public class GetInstructionsRequest
    {
        /// <summary>
        /// the raw instructions to be processed
        /// </summary>
        public string RawInstructions { get; set; } = string.Empty;
    }
}
