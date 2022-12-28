using Day11.Models.Enums;
using Day11.Models.Requests;
using Day11.Models.Responses;

namespace Day11.Models
{
    /// <summary>
    /// the monkey object that is being tracked
    /// </summary>
    public class Monkey
    {
        /// <summary>
        /// the name of the monkey being tracked
        /// </summary>
        public int MonkeyName { get; set; } = 0;

        /// <summary>
        /// the items that are being tracked
        /// </summary>
        public List<int> Items { get; set; } = new List<int>();

        /// <summary>
        /// the number of times the monkey inspected an item
        /// </summary>
        public int Inspections { get; set; } = 0;

        /// <summary>
        /// the number to be tested by
        /// </summary>
        public int Test { get; set; } = 0;

        /// <summary>
        /// the monkey to throw to if the test is true
        /// </summary>
        public Monkey TestTrue { get; set; } = null!;

        /// <summary>
        /// the monkey to throw to if the test is false
        /// </summary>
        public Monkey TestFalse { get; set; } = null!;

        /// <summary>
        /// string stating the value that the worry should change by
        /// </summary>
        public string WorryFactor { get; set; } = string.Empty;

        /// <summary>
        /// the type of operator the worry factor is changed by
        /// </summary>
        public OperatorEnum WorryOperator { get; set; } = OperatorEnum.None;

        public async Task<ChangeWorryResponse> ChangeWorry(ChangeWorryRequest request)
        {
            var response = new ChangeWorryResponse();

            try
            {
                int worryInt = 0;
                if (!int.TryParse(request.WorryAdjustment, out worryInt))
                {
                    worryInt = request.Worry;
                }

                switch (request.Operator)
                {
                    case OperatorEnum.Add:
                        response.Worry = request.Worry + worryInt;
                        break;

                    case OperatorEnum.Subtract:
                        response.Worry = request.Worry - worryInt;
                        break;

                    case OperatorEnum.Multiply:
                        response.Worry = request.Worry * worryInt;
                        break;

                    case OperatorEnum.Divide:
                        response.Worry = request.Worry / worryInt;
                        break;

                    default:
                        throw new Exception("Couldn't adjust worry");
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
