using Day10.Models.Enums;
using System.Text;

namespace Day10.Models.Responses
{
    /// <summary>
    /// the response object containing data about the screen display
    /// </summary>
    public class CheckScreenCycleResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the display of the screen
        /// </summary>
        public string ScreenDisplay { get; set; } = string.Empty;

        /// <summary>
        /// the cycle after screen check
        /// </summary>
        public int Cycle { get; internal set; }
    }
}
