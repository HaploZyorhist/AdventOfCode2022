using Day01.Factories;
using System.Text;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _elfFactory = new ElfFactory();

string[] individualElves = data.Split("\r\n\r\n");

var elves = _elfFactory.GenerateElves(individualElves);

var orderedElves = elves.OrderByDescending(x => x.TotalLoad).ToList();

var biggesElf = orderedElves[0];
var secondElf = orderedElves[1];
var thirdElf = orderedElves[2];

var sb = new StringBuilder();

sb.AppendLine($"The elf carrying the largest load is carrying {biggesElf.TotalLoad} calories");
sb.AppendLine($"The top 3 elves are carrying {biggesElf.TotalLoad}, {secondElf.TotalLoad}, and {thirdElf.TotalLoad}");
sb.AppendLine($"respectively, for a total of {biggesElf.TotalLoad + secondElf.TotalLoad + thirdElf.TotalLoad} calories.");

Console.WriteLine(sb.ToString());
Console.ReadKey();