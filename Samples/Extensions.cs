using System.Linq;
using System.Net.Http.Headers;

namespace Samples;

public static class Extensions
{
    public static IEnumerable<T> Pagination<T>(this IEnumerable<T> data, int pageIndex, int pageSize) =>
        data.Skip(pageIndex * pageSize).Take(pageSize);

    public static IEnumerable<T> PaginationFaster<T>(this IEnumerable<T> data, int pageIndex, int pageSize) =>
        data.Take((pageIndex * pageSize)..pageSize);

    public static IEnumerable<T> FirstPage<T>(this IEnumerable<T> data, int PageSize) =>
        data.Take(PageSize);

    public static IEnumerable<T> LastPage<T>(this IEnumerable<T> data, int pageSize) =>
        data.Skip((data.Count() / pageSize - 1) * pageSize).Take(pageSize);

    public static IEnumerable<T> LastPageBest<T>(this IEnumerable<T> data, int pageSize) =>
        data.Skip((data.PageCount(pageSize) - 1) * pageSize).Take(pageSize);

    public static IEnumerable<T> QuickPagination<T>(this IEnumerable<T> data, int lastIndex, int pageSize) where T : IdModel =>
         data.AsQueryable().Where(x => x.Id > lastIndex).Take(pageSize).ToList();

    public static int PageCount<T>(this IEnumerable<T> data, int pageSize)
    {
        var totalData = data.Count();
        return totalData / pageSize + (totalData % pageSize > 0 ? 1 : 0);
    }
}
