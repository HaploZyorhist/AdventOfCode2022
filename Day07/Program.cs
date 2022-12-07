using Day07.Factories;
using Day07.Models.Enums;
using Day07.Models.Requests;
using Day07.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _directoryService = new DirectoryService();

try
{
    var processDataRequest = new DataProcessRequest
    {
        RawData= data,
    };

    var processDataResponse = await _dataProcessingFactory.ProcessRawData(processDataRequest);

    if (processDataResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not properly process data");
    }

    var getSmallDirectoryRequest = new GetSmallDirectoryRequest
    {
        RootDirectory = processDataResponse.RootDirectory,
    };

    var getSmallDirectoryResponse = await _directoryService.GetSmallDirectories(getSmallDirectoryRequest);

    if(getSmallDirectoryResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not get small directories");
    }

    int totalSize = 0;

    getSmallDirectoryResponse.SmallDirectories.ForEach(async x => totalSize += await x.GetDirectorySize());

    Console.WriteLine($"There were a total of {getSmallDirectoryResponse.SmallDirectories.Count} total directories under the threshold");
    Console.WriteLine($"Their total size is {totalSize}");


    var getLargeDirectoryRequest = new GetLargeDirectoryRequest
    {
        RootDirectory = processDataResponse.RootDirectory,
    };

    var getLargeDirectoryResponse = await _directoryService.GetLargeDirectories(getLargeDirectoryRequest);

    if (getLargeDirectoryResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not get large directories over requirement");
    }

    var sizeList = new List<int>();

    getLargeDirectoryResponse.LargeDirectories.ForEach(async x => sizeList.Add(await x.GetDirectorySize()));

    sizeList = sizeList.OrderBy(x => x).ToList();

    Console.WriteLine($"The directory that is the smalles over the requirement is {sizeList.First()} units");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();