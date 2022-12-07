using Day07.Factories;
using Day07.Models.Enums;
using Day07.Models.Requests;
using Day07.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\TestData.txt");
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


}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();