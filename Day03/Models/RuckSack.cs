namespace Day03.Models
{
    /// <summary>
    /// the rucksack with its contents
    /// </summary>
    public class RuckSack
    {
        /// <summary>
        /// the contents of the first compartment
        /// </summary>
        public string CompartmentA { get; set; } = string.Empty;

        /// <summary>
        /// the contents of the second compartment
        /// </summary>
        public string CompartmentB { get; set;} = string.Empty;

        /// <summary>
        /// the raw data of the contents of the sack
        /// </summary>
        public string RawData { get; set;} = string.Empty;
    }
}
