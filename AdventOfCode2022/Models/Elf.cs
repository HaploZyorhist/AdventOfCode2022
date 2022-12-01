using System.Net;

namespace Day01.Models
{
    /// <summary>
    /// object for containing data regarding the elves and their loads
    /// </summary>
    public class Elf
    {
        /// <summary>
        /// the different callories carried in each piece of their loads
        /// </summary>
        public List<int> LoadValues { get; set; } = new List<int>();

        /// <summary>
        /// the total calorie count for the load they are carrying
        /// </summary>
        public int TotalLoad { get; set; }
    }
}
