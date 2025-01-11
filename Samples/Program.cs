using Samples;

const int PAGE_SIZE = 25;
const int PAGE_INDEX = 5;

var data = Enumerable.Range(0, 1005).Select(i => i + 1).ToList();

var first = data.FirstPage(PAGE_SIZE).ToList();
Console.WriteLine("--------- First");
first.ForEach(i => Console.WriteLine(i));

var last = data.LastPage(PAGE_SIZE).ToList();
Console.WriteLine("--------- Last");
last.ForEach(i => Console.WriteLine(i));

var lastBest = data.LastPageBest(PAGE_SIZE).ToList();
Console.WriteLine("--------- Last Best");
lastBest.ForEach(i => Console.WriteLine(i));

var page5 = data.Pagination(PAGE_INDEX, PAGE_SIZE).ToList();
Console.WriteLine("--------- page 5");
page5.ForEach(i => Console.WriteLine(i));

var page6 = data.PaginationFaster(PAGE_INDEX, PAGE_SIZE).ToList();
Console.WriteLine("--------- page faster");
page5.ForEach(i => Console.WriteLine(i));

var countOfPages = data.PageCount(PAGE_SIZE);
Console.WriteLine($"Count of pages : {countOfPages}");

var newData = Enumerable.Range(1,40000000).Select(x=> new Model { 
    Id = x,
    RandomData = Random.Shared.Next(10000000,99999999),
}).ToList();


/*
 * in this senario we should save last id
 */
newData.QuickPagination(120000, PAGE_SIZE);