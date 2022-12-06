using Day05.Models;
using Day05.Models.Enums;
using Day05.Models.Requests;
using Day05.Models.Responses;

namespace Day05.Factories
{
    /// <summary>
    /// factory for creating instructions and the lists of crates
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for cleaning up the raw data
        /// </summary>
        /// <param name="request">contains the raw data to clean up</param>
        /// <returns>object containing cleaned data objects</returns>
        public async Task<CleanDataResponse> ProcessRawData(CleanDataRequest request)
        {
            var response = new CleanDataResponse();

            try
            {
                var dataSplit = request.RawData.Split("\r\n\r\n");

                var shipModel = dataSplit[0];

                var shipConfigurationRequest = new ShipConfigurationRequest
                {
                    RawConfiguration = shipModel,
                };

                // my attempt at a tiny bit of parallel programming
                var shipConfigurationTask = Task.Run(() => GetShipConfiguration(shipConfigurationRequest));

                var instructionList = dataSplit[1];

                var instructionRequest = new GetInstructionsRequest
                {
                    RawInstructions = instructionList,
                };

                var cleanInstructionsTask = Task.Run(() => GetInstructions(instructionRequest));

                await shipConfigurationTask;
                var shipConfiguration = shipConfigurationTask.Result;

                if (shipConfiguration is not { Status: StatusEnum.Success })
                {
                    throw new Exception("Could not process ship configuration");
                }

                await cleanInstructionsTask;
                var cleanInstructions = cleanInstructionsTask.Result;

                if (cleanInstructions is not { Status: StatusEnum.Success })
                {
                    throw new Exception("Could not process instructions");
                }

                response.CargoStacks = shipConfiguration.CargoStacks;
                response.CargoStacksRevised = shipConfiguration.CargoStacksRevised;
                response.Instructions = cleanInstructions.Instructions;

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
        /// method for getting the current configuration of the ship
        /// </summary>
        /// <param name="request">object containing raw data about the configuration of the ship</param>
        /// <returns>object containing clean ship configuration data</returns>
        private async Task<ShipConfigurationResponse> GetShipConfiguration(ShipConfigurationRequest request)
        {
            var response = new ShipConfigurationResponse();

            try
            {
                var stacks = request.RawConfiguration.Split("\r\n");

                foreach (var stack in stacks.Reverse())
                {
                    for (var i = 0; i < (stack.Length + 1) / 4; i++)
                    {
                        var stackConfiguration = stack.Substring(i * 4, 3);

                        if (int.TryParse(stackConfiguration, out int stackNumber))
                        {
                            var stackContents = new Stack<string>();
                            var stackContentsRevised = new Stack<string>();

                            response.CargoStacks.Add(stackContents);
                            response.CargoStacksRevised.Add(stackContentsRevised);
                        }
                        else if (!string.IsNullOrWhiteSpace(stackConfiguration))
                        {
                            response.CargoStacks[i].Push(stackConfiguration[1].ToString());
                            response.CargoStacksRevised[i].Push(stackConfiguration[1].ToString());
                        }
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
        /// private method for getting the instructions cleaned
        /// </summary>
        /// <param name="request">object containing raw instruction data</param>
        /// <returns>object containing cleaned instructions</returns>
        private async Task<GetInstructionsResponse> GetInstructions(GetInstructionsRequest request)
        {
            var response = new GetInstructionsResponse();

            try
            {
                var instructionSplit = request.RawInstructions.Split("\r\n");

                foreach (var instruction in instructionSplit)
                {
                    var instructionReturn = new Instruction();

                    var instructionBreakdown = instruction.Split(" ");

                    instructionReturn.Move = int.Parse(instructionBreakdown[1]);
                    instructionReturn.Start = int.Parse(instructionBreakdown[3]);
                    instructionReturn.End = int.Parse(instructionBreakdown[5]);

                    response.Instructions.Enqueue(instructionReturn);
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
