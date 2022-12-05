using Day03.Factories;
using Day03.Models.Enums;
using Day03.Models.Requests;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _pointFactory = new PointFactory();
var _sackFactory = new SackFactory();

var sacks = data.Split("\r\n").ToList();

try
{
    var ruckRequest = new GetCompartmentsRequest
    {
        SackData = sacks,
    };

    var ruckResponse = await _sackFactory.GetCompartmentsComponents(ruckRequest);

    if (ruckResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get ruck contents");
    }

    #region Part 1

    var duplicateRequest = new GetDuplicateRequest
    {
        RuckSacks = ruckResponse.RuckSacks,
    };

    var duplicateResponse = await _sackFactory.GetDuplicateItems(duplicateRequest);

    if (duplicateResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not find duplicate items");
    }

    var duplicateItemPoints = new GetPointsRequest
    {
        Items = duplicateResponse.Duplicates
    };

    var pointResponse = await _pointFactory.GetPoints(duplicateItemPoints);

    if (pointResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get points");
    }

    #endregion

    #region Part 2

    var badgesRequest = new GetBadgeRequest
    {
        Rucks = ruckResponse.RuckSacks
    };

    var badgesResponse = await _sackFactory.GetBadgeItems(badgesRequest);

    if (badgesResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get badges");
    }

    var badgePointRequest = new GetPointsRequest
    {
        Items = badgesResponse.Badges
    };

    var badgePointResponse = await _pointFactory.GetPoints(badgePointRequest);

    if (badgePointResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get points for badges");
    }

    #endregion

    Console.WriteLine($"The total points for duplicate items is {pointResponse.TotalPoints}");
    Console.WriteLine($"The total points for the badges is {badgePointResponse.TotalPoints}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();