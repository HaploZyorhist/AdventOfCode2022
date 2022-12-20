using Day09.Models;
using Day09.Models.Enums;
using Day09.Models.Requests;
using Day09.Models.Responses;

namespace Day09.Factories
{
    /// <summary>
    /// factory for handling data 
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for handling raw data
        /// </summary>
        /// <param name="request">object containing raw data</param>
        /// <returns>object containing results of data processing</returns>
        public async Task<ProcessDataResponse> ProcessData(ProcessDataRequest request)
        {
            var response = new ProcessDataResponse();

            try
            {
                var rawInstructions = request.RawData.Split("\r\n");

                foreach ( var rawInstruction in rawInstructions )
                {
                    var newInstruction = new Instruction();

                    var instructionSplit = rawInstruction.Split(" ");

                    switch (instructionSplit[0])
                    {
                        case "U":
                            newInstruction.Direction = DirectionEnum.Up;
                            break;

                        case "D":
                            newInstruction.Direction = DirectionEnum.Down;
                            break;

                        case "L":
                            newInstruction.Direction = DirectionEnum.Left;
                            break;

                        case "R":
                            newInstruction.Direction = DirectionEnum.Right;
                            break;

                        default:
                            throw new Exception("Could not get direction from the parse");
                    }

                    newInstruction.Spaces = int.Parse(instructionSplit[1]);

                    response.Instructions.Add(newInstruction);
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
