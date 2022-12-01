using Day01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Factories
{
    /// <summary>
    /// factory for setting up elf objects
    /// </summary>
    public class ElfFactory
    {
        public List<Elf> GenerateElves(string[] rawElfData)
        {
            List<Elf> elves = new List<Elf>();

            for (int i = 0; i < rawElfData.Length; i++)
            {
                var elf = new Elf();
                var elfCarrying = rawElfData[i].Split("\r\n");

                foreach (var load in elfCarrying)
                {
                    elf.LoadValues.Add(int.Parse(load));
                }

                elf.TotalLoad = elf.LoadValues.Sum();

                elves.Add(elf);
            }

            return elves;
        }
    }
}
