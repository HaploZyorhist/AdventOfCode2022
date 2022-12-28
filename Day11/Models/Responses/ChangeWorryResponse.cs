using Day11.Models.Enums;

namespace Day11.Models.Responses
{
    /// <summary>
    /// the response for changing the worry of an item
    /// </summary>
    public class ChangeWorryResponse
    {
        /// <summary>
        /// the status of the change worry request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the worry after it has been adjusted
        /// </summary>
        public int Worry { get; set; } = 0;
    }
}
