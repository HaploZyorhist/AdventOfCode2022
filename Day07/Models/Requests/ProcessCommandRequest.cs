namespace Day07.Models.Requests
{
    /// <summary>
    /// object containing the data needed to process a command
    /// </summary>
    public class ProcessCommandRequest
    {
        /// <summary>
        /// the command that is going to be executed
        /// </summary>
        public string Command { get; set; } = string.Empty;

        /// <summary>
        /// the current active directory
        /// </summary>
        public SystemDirectory Directory { get; set; } = new SystemDirectory();
    }
}
