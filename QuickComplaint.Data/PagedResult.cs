using System;
using System.Collections.ObjectModel;

public class PagedResult<T>
{

	public PagedResult(int requestedPage, int requestedPageSize, Int64 recordCount, Collection<T> data)
	{
		Int32 totalPages = default(Int32);
		if (recordCount > 0) {
			totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordCount) / requestedPageSize));
		}

		TotalCount = recordCount;
		PageCount = totalPages;
		PageSize = requestedPageSize;
		CurrentPage = requestedPage;
		Results = data;
	}

	public Collection<T> Results { get; set; }
	public int CurrentPage { get; set; }
	public int PageCount { get; set; }
	public int PageSize { get; set; }
	public Int64 TotalCount { get; set; }
}
