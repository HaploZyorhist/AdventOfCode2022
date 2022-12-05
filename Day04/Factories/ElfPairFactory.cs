using Day04.Models;
using Day04.Models.Enums;
using Day04.Models.Requests;
using Day04.Models.Responses;

namespace Day04.Factories
{
    /// <summary>
    /// factory for handling elf pairs
    /// </summary>
    public class ElfPairFactory
    {
        /// <summary>
        /// method for creating elf pairs 
        /// </summary>
        /// <param name="request">object containing raw data on the elf pairs</param>
        /// <returns>object containing data on the elf pairs</returns>
        public async Task<ElfPairResponse> GetElfPairs(ElfPairRequest request)
        {
            var response = new ElfPairResponse();

            try
            {
                foreach (var pair in request.ElfPairData)
                {
                    var elfPair = new ElfPairs();

                    var elves = pair.Split(",").ToList();

                    var elfACoords = elves[0].Split("-").ToList();

                    elfPair.ElfAStart = int.Parse(elfACoords[0]);

                    elfPair.ElfAStop = int.Parse(elfACoords[1]);

                    var elfBCoords = elves[1].Split("-").ToList();

                    elfPair.ElfBStart = int.Parse(elfBCoords[0]);

                    elfPair.ElfBStop = int.Parse(elfBCoords[1]);

                    response.Pairs.Add(elfPair);
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }

        /// <summary>
        /// method for getting the elves that have been completely overlapped
        /// </summary>
        /// <param name="request">object containing data on elf positioning</param>
        /// <returns>object with a count of elves that are overlapped</returns>
        public async Task<OverlapResponse> GetCompletelyOverlappedElves(OverlapRequest request)
        {
            var response = new OverlapResponse();

            try
            {
                foreach (var pair in request.ElfPairs)
                {
                    if ((pair.ElfAStart <= pair.ElfBStart && pair.ElfAStop >= pair.ElfBStop) ||
                        (pair.ElfAStart >= pair.ElfBStart && pair.ElfAStop <= pair.ElfBStop))
                    {
                        response.OverlapCount++;
                    }
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }

        /// <summary>
        /// method for getting the elves that have been partially overlapped
        /// </summary>
        /// <param name="request">object containing data on elf positioning</param>
        /// <returns>object with a count of elves that are overlapped</returns>
        public async Task<OverlapResponse> GetPartiallyOverlappedElves(OverlapRequest request)
        {
            var response = new OverlapResponse();

            try
            {
                foreach (var pair in request.ElfPairs)
                {
                    if ((pair.ElfAStart >= pair.ElfBStart && pair.ElfAStart <= pair.ElfBStop) ||
                        (pair.ElfAStop >= pair.ElfBStart && pair.ElfAStop <= pair.ElfBStop) ||
                        (pair.ElfAStart <= pair.ElfBStart && pair.ElfAStop >= pair.ElfBStop) ||
                        (pair.ElfAStart >= pair.ElfBStart && pair.ElfAStop <= pair.ElfBStop))
                    {
                        response.OverlapCount++;
                    }
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }
    }
}
