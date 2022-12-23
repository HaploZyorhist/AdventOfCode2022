using System.Text;

namespace Day10.Models.Requests
{
    /// <summary>
    /// object containing data for figuring out the screen display
    /// </summary>
    public class CheckScreenCycleRequest
    {
        /// <summary>
        /// the cycle the clock is on
        /// </summary>
        public int Cycle { get; set; } = 0;

        /// <summary>
        /// the strength of the signal
        /// </summary>
        public int SignalStrength { get; set; } = 0; 

        /// <summary>
        /// the current screen display
        /// </summary>
        public string ScreenDisplay { get; set; } = string.Empty;
    }
}
