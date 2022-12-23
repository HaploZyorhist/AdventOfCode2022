using Day10.Models.Enums;
using System.Text;

namespace Day10.Models.Responses
{
    /// <summary>
    /// object containing the results of the screen display
    /// </summary>
    public class GetScreenResponse
    {
        /// <summary>
        /// the status of the response
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the output that is displayed to the screen
        /// </summary>
        public string Output { get; set; } = string.Empty;
    }
}
