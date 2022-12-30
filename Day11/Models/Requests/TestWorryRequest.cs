namespace Day11.Models.Requests
{
    /// <summary>
    /// object containing data on what is to be tested by the monkey
    /// </summary>
    public class TestWorryRequest
    {
        /// <summary>
        /// the value of worry that is to be tested
        /// </summary>
        public ulong WorryValue { get; set; } = 0;

        /// <summary>
        /// the value that the worry is to be tested against
        /// </summary>
        public ulong TestValue { get; set; } = 0; 
    }
}
