using Day03.Models;
using Day03.Models.Enums;
using Day03.Models.Requests;
using Day03.Models.Responses;

namespace Day03.Factories
{
    /// <summary>
    /// factory for handling the contents of rucksacks
    /// </summary>
    public class SackFactory
    {
        /// <summary>
        /// method for getting the contents of each compartment of the rucksack
        /// </summary>
        /// <param name="request">object containing the data for the ruck sack</param>
        /// <returns>object containing the ruck sack contents</returns>
        public async Task<GetCompartmentsResponse> GetCompartmentsComponents(GetCompartmentsRequest request)
        {
            var response = new GetCompartmentsResponse();

            try
            {
                foreach (var items in request.SackData)
                {
                    var ruck = new RuckSack();

                    ruck.RawData = items;

                    var ruckSize = items.Length;

                    ruck.CompartmentA = items.Remove(ruckSize / 2, ruckSize / 2);
                    ruck.CompartmentB = items.Remove(0, ruckSize / 2);

                    response.RuckSacks.Add(ruck);
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return response;
            }

        }

        /// <summary>
        /// method for finding duplicate items
        /// </summary>
        /// <param name="request">object containing list of ruck sacks with items</param>
        /// <returns>object containing list of duplicate items</returns>
        public async Task<GetDuplicateResponse> GetDuplicateItems(GetDuplicateRequest request)
        {
            var response = new GetDuplicateResponse();

            try
            {
                foreach (var sack in request.RuckSacks)
                {
                    var items = sack.CompartmentA.ToCharArray();

                    foreach (var item in items)
                    {
                        if (sack.CompartmentB.Contains(item))
                        {
                            response.Duplicates.Add(item);
                            break;
                        }
                    }
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return response;
            }
        }

        /// <summary>
        /// method for getting the items that are badges
        /// </summary>
        /// <param name="request">object containing the ruck sack contents</param>
        /// <returns>object containing the identity of the badges</returns>
        public async Task<GetBadgeResponse> GetBadgeItems(GetBadgeRequest request)
        {
            var response = new GetBadgeResponse();
            try
            {
                for (var i = 0; i < request.Rucks.Count / 3; i++)
                {
                    var elfGroup = request.Rucks.Skip(i * 3).Take(3).ToList();

                    var leader = elfGroup.First();

                    foreach(var item in leader.RawData.ToCharArray())
                    {
                        if (elfGroup[1].RawData.Contains(item) && elfGroup[2].RawData.Contains(item))
                        {
                            response.Badges.Add(item);
                            break;
                        }
                    }
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return response;
            }
        }
    }
}
