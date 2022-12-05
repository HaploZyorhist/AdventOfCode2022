using System.Numerics;

namespace Day04.Models
{
    /// <summary>
    /// pais of elves with their assignments
    /// </summary>
    public class ElfPairs
    {
        /// <summary>
        /// the starting point for elf a
        /// </summary>
        public int ElfAStart { get; set; } = 0;

        /// <summary>
        /// the stopping point for elf a
        /// </summary>
        public int ElfAStop { get; set; } = 0;

        /// <summary>
        /// the starting point for elf b
        /// </summary>
        public int ElfBStart { get; set; } = 0;

        /// <summary>
        /// the stopping for elf b
        /// </summary>
        public int ElfBStop { get; set; } = 0;
    }
}
