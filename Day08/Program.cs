using Day08.Factories;
using Day08.Models.Enums;
using Day08.Models.Requests;
using Day08.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _treeVisibilityService = new TreeVisibilityService();

try
{
    var processDataRequest = new ProcessDataRequest
    {
        RawData = data,
    };

    var processDataResponse = await _dataProcessingFactory.ProcessData(processDataRequest);

    if (processDataResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not properly process data");
    }

    Console.WriteLine($"A total of {processDataResponse.Trees.Count()} trees were mapped");

    var treeVisibilityRequest = new TreeVisibilityRequest
    {
        TreeColumns = processDataResponse.TreeColumns,
        TreeRows = processDataResponse.TreeRows,
        Trees = processDataResponse.Trees,
    };

    var processVisibilty = await _treeVisibilityService.MarkVisibleTrees(treeVisibilityRequest);

    if (processVisibilty is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not process visibility of trees");
    }

    var findATree = processVisibilty.Trees.Where(x => x.Visible == true).ToList();

    Console.WriteLine($"Found a total of {findATree.Count()} trees that are visible");

    var highViewFactorRequest = new GetHighestViewFactorRequest
    {
        Trees = processVisibilty.Trees,
    };

    var highViewFactorResponse = await _treeVisibilityService.GetHighestViewFactor(highViewFactorRequest);

    if (highViewFactorResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not get highest view factor");
    }

    Console.WriteLine($"The highest view factor among trees is {highViewFactorResponse.ViewFactor}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();
