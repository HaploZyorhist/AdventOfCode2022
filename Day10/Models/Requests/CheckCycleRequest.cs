namespace Day10.Models.Requests
{
    /// <summary>
    /// object containing the data for checking cycle
    /// </summary>
    public class CheckCycleRequest
    {
        /// <summary>
        /// the current signal strength
        /// </summary>
        public int SignalStrength { get; set; } = 0;

        /// <summary>
        /// the cycle that we are currently checking
        /// </summary>
        public int Cycle {  get; set; } = 0;

        /// <summary>
        /// the signal strength of the instruction
        /// </summary>
        public int InstructionStrength { get; set; } = 0; 
    }
}
