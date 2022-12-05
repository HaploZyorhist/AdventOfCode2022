using Day04.Factories;
using Day04.Models.Enums;
using Day04.Models.Requests;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _pairFactory = new ElfPairFactory();

var pairs = data.Split("\r\n").ToList();

try
{
    var pairRequest = new ElfPairRequest
    {
        ElfPairData = pairs,
    };

    var pairResponse = await _pairFactory.GetElfPairs(pairRequest);

    if (pairResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not create elf pairs");
    }

    var overlapRequest = new OverlapRequest
    {
        ElfPairs = pairResponse.Pairs,
    };

    var totalOverlapResponse = await _pairFactory.GetCompletelyOverlappedElves(overlapRequest);

    if (totalOverlapResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get a count of totally overlapped pairs");
    }

    var partialOverlapResponse = await _pairFactory.GetPartiallyOverlappedElves(overlapRequest);

    if (partialOverlapResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get a count of partially overlapped pairs");
    }

    Console.WriteLine($"The count of completely overlapped elves is {totalOverlapResponse.OverlapCount}");
    Console.WriteLine($"The count of partially overlapped elves is {partialOverlapResponse.OverlapCount}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();