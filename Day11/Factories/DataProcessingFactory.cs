using Day11.Models;
using Day11.Models.Enums;
using Day11.Models.Requests;
using Day11.Models.Responses;

namespace Day11.Factories
{
    /// <summary>
    /// factory for handling data
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for processing raw data
        /// </summary>
        /// <param name="request">object containing raw data</param>
        /// <returns>object containing processed data</returns>
        public async Task<ProcessDataResponse> ProcessRawData(ProcessDataRequest request)
        {
            var response = new ProcessDataResponse();

            try
            {
                var rawMonkeys = request.RawData.Split("\r\n\r\n");

                for (int i = 0; i < rawMonkeys.Count(); i++)
                {
                    var newMonkey = new Monkey
                    {
                        MonkeyName = i
                    };

                    response.MonkeyList.Add(newMonkey);
                }

                foreach (var rawMonkey in rawMonkeys)
                {
                    var rawMonkeyData = rawMonkey.Split("\r\n").ToList();

                    var heldItems = rawMonkeyData.Where(x => x.Contains("Starting items: ")).First().Trim().Replace("Starting items: ", "").Split(", ").ToList();

                    var monkey = response.MonkeyList.Where(x => x.MonkeyName == int.Parse(rawMonkeyData[0].Trim().Replace("Monkey ", "").Replace(":", ""))).First();

                    monkey.Test = int.Parse(rawMonkeyData.Where(x => x.Contains("Test:")).First().Trim().Replace("Test: divisible by ", ""));

                    var testTrue = int.Parse(rawMonkeyData.Where(y => y.Contains("If true: throw to monkey ")).First().Trim().Replace("If true: throw to monkey ", ""));

                    monkey.TestTrue = response.MonkeyList.Where(x => x.MonkeyName == testTrue).First();

                    var testFalse = int.Parse(rawMonkeyData.Where(y => y.Contains("If false: throw to monkey ")).First().Trim().Replace("If false: throw to monkey ", ""));

                    monkey.TestFalse = response.MonkeyList.Where(x => x.MonkeyName == testFalse).First();

                    var adjustmentData = rawMonkeyData.Where(x => x.Contains("Operation: ")).First().Trim().Replace("Operation: new = old ", "").Split(" ").ToList();

                    switch (adjustmentData[0])
                    {
                        case "+":
                            monkey.WorryOperator = OperatorEnum.Add;
                            break;

                        case "*":
                            monkey.WorryOperator = OperatorEnum.Multiply;
                            break;

                        case "-":
                            monkey.WorryOperator = OperatorEnum.Subtract;
                            break;

                        case "/":
                            monkey.WorryOperator = OperatorEnum.Divide;
                            break;

                        default:
                            throw new Exception("could not get worry operator");
                    }

                    monkey.WorryFactor = adjustmentData[1];

                    foreach (var item in heldItems)
                    {
                        monkey.Items.Add(int.Parse(item));
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
