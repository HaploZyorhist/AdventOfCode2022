using Day07.Models.Enums;

namespace Day07.Models.Responses
{
    /// <summary>
    /// object containing the results of processing a command
    /// </summary>
    public class ProcessCommandResponse
    {
        /// <summary>
        /// the results of processing the command
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the file directory that is active after the command is executed
        /// </summary>
        public SystemDirectory Directory { get; set; } = new SystemDirectory();
    }
}
