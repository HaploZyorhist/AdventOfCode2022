using Day08.Models;
using Day08.Models.Enums;
using Day08.Models.Requests;
using Day08.Models.Responses;
using System.Numerics;

namespace Day08.Factories
{
    /// <summary>
    /// factory for processing the raw data
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for handling the raw data
        /// </summary>
        /// <param name="request">object containing raw data to be processed</param>
        /// <returns>object with cleaned data</returns>
        public async Task<ProcessDataResponse> ProcessData(ProcessDataRequest request)
        {
            var response = new ProcessDataResponse();
            try
            {
                var dataRows = request.RawData.Split("\r\n");
                var columnsCount = dataRows[0].Length;
                var rowsCount = dataRows.Count();

                var treeList = new List<Tree>();

                for (var rows = 0; rows < rowsCount; rows++)
                {
                    var columnContents = dataRows[rows].ToCharArray();

                    for (var columns = 0; columns < columnsCount; columns++)
                    {
                        var height = int.Parse(columnContents[columns].ToString());

                        var tree = new Tree
                        {
                            Coords = new Vector2
                            {
                                X = columns,
                                Y = rows
                            },
                            Height = height,
                        };

                        treeList.Add(tree);
                    }
                }

                response.TreeRows = rowsCount;
                response.TreeColumns = columnsCount;
                response.Trees = treeList;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return response;
            }
        }
    }
}
