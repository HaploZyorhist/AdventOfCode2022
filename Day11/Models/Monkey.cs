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
        public List<ulong> Items { get; set; } = new List<ulong>();

        /// <summary>
        /// the number of times the monkey inspected an item
        /// </summary>
        public int Inspections { get; set; } = 0;

        /// <summary>
        /// the number to be tested by
        /// </summary>
        public ulong Test { get; set; } = 0;

        /// <summary>
        /// the monkey to throw to if the test is true
        /// </summary>
        public int TestTrue { get; set; } = 0;

        /// <summary>
        /// the monkey to throw to if the test is false
        /// </summary>
        public int TestFalse { get; set; } = 0;

        /// <summary>
        /// string stating the value that the worry should change by
        /// </summary>
        public string WorryFactor { get; set; } = string.Empty;

        /// <summary>
        /// the type of operator the worry factor is changed by
        /// </summary>
        public OperatorEnum WorryOperator { get; set; } = OperatorEnum.None;

        /// <summary>
        /// method for changing worry when an item is inspected
        /// </summary>
        /// <param name="request">item with details on the object being inspected</param>
        /// <returns>response containing new values for the worry of the item</returns>
        public async Task<ChangeWorryResponse> ChangeWorry(ChangeWorryRequest request)
        {
            var response = new ChangeWorryResponse();

            try
            {
                ulong worryInt = 0;
                if (!ulong.TryParse(request.WorryAdjustment, out worryInt))
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

                Inspections++;

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
        /// method for testing the worry value of an item to know where to throw it
        /// </summary>
        /// <param name="request">object containing data on the item and test</param>
        /// <returns>indicator of whether the test was a success</returns>
        public async Task<TestWorryResponse> TestWorry(TestWorryRequest request)
        {
            var response = new TestWorryResponse();

            try
            {
                if (request.WorryValue == 0 || request.TestValue == 0)
                {
                    throw new Exception("Worry or test value is invalid");
                }

                if (request.WorryValue % request.TestValue == 0)
                {
                    response.Result = true;
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
