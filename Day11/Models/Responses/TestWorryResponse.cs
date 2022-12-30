using Day11.Models.Enums;

namespace Day11.Models.Responses
{
    /// <summary>
    /// object returning data on the worry test
    /// </summary>
    public class TestWorryResponse
    {
        /// <summary>
        /// indicator of whether the request was a success
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// indicator of whether the test was a success
        /// </summary>
        public bool Result { get; set; } = false;
    }
}
