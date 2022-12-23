using Day10.Models;
using Day10.Models.Enums;
using Day10.Models.Requests;
using Day10.Models.Responses;

namespace Day10.Factories
{
    /// <summary>
    /// factory for handling data
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for processing raw data
        /// </summary>
        /// <param name="reqeust">object containing data to be processed</param>
        /// <returns>object containing instruction data to be followed</returns>
        public async Task<DataProcessingResponse> ProcessData(DataProcessingRequest request)
        {
            var response = new DataProcessingResponse();

            try
            {
                var directives = request.RawData.Split("\r\n").ToList();

                var instructions = new List<Instruction>();

                foreach (var directive in directives)
                {
                    if(string.Equals(directive, "noop", StringComparison.OrdinalIgnoreCase))
                    {
                        instructions.Add(new Instruction
                        {
                            Type = InstructionEnum.Noop,

                        });

                        continue;
                    }

                    var directiveSplit = directive.Split(" ");

                    instructions.Add(new Instruction
                    {
                        Type = InstructionEnum.Add,
                        Strength = int.Parse(directiveSplit[1]),
                    });
                }

                response.Instructions = instructions;

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
