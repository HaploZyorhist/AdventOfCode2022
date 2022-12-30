using Day11.Models.Enums;

namespace Day11.Models.Requests
{
    /// <summary>
    /// reqeust for changing a monkey's worry
    /// </summary>
    public class ChangeWorryRequest
    {
        /// <summary>
        /// the starting worry for the item
        /// </summary>
        public ulong Worry { get; set; } = 0;

        /// <summary>
        /// the adjustment that the worry should make
        /// </summary>
        public string WorryAdjustment { get; set; } = string.Empty;

        /// <summary>
        /// the operator that should be used
        /// </summary>
        public OperatorEnum Operator { get; set; } = OperatorEnum.None;
    }
}
