using Day05.Models.Enums;
using Day05.Models.Requests;
using Day05.Models.Responses;

namespace Day05.Services
{
    /// <summary>
    /// service for handling instructions and reconfiguring the ship
    /// </summary>
    public class ShipProcessingRequest
    {
        /// <summary>
        /// method for processing the crane instructions and reconfiguring the ship stacks
        /// </summary>
        /// <param name="request">object containing the ship configuration and the ship stacks</param>
        /// <returns>object containing the new ship configuration after after instructions have been performed</returns>
        public async Task<ProcessInstructionsResponse> ProcessInstructions(ProcessInstructionsRequest request)
        {
            var response = new ProcessInstructionsResponse();

            try
            {
                var configuration = request.CargoStacks;
                var configurationRevised = request.CargoStacksRevised;

                while (request.Instructions.Count > 0)
                {
                    var instruction = request.Instructions.Dequeue();

                    var tempStack = new Stack<string>();
                    for (int i = 0; i < instruction.Move; i++)
                    {
                        var cargo = configuration[instruction.Start - 1].Pop();
                        var cargoRevised = configurationRevised[instruction.Start - 1].Pop();

                        configuration[instruction.End - 1].Push(cargo);
                        tempStack.Push(cargoRevised);
                    }

                    foreach (var crate in tempStack)
                    {
                        configurationRevised[instruction.End - 1].Push(crate);
                    }

                }

                response.CargoStacks = configuration;
                response.CargoStacksRevised = configurationRevised;

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
        /// method for getting the top character of each stack
        /// </summary>
        /// <param name="request">object containing the configuration of the ship</param>
        /// <returns>object containing the top crate from each stack</returns>
        public async Task<TopStackResponse> GetTopStack(TopStackRequest request)
        {
            var response = new TopStackResponse();

            try
            {
                string topCrates = string.Empty;
                var topCratesRevised = string.Empty;

                for (int i = 0; i < request.CargoStacks.Count; i++)
                {
                    topCrates += request.CargoStacks[i].Pop();
                    topCratesRevised += request.CargoStacksRevised[i].Pop();
                }

                response.StackResponse = topCrates;
                response.StackResponseRevised = topCratesRevised;

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
