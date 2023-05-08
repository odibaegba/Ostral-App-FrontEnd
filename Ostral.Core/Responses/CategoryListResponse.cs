namespace Ostral.Core.Responses;

public class CategoryListResponse
{
    public IEnumerable<CategoryListItem> Categories { get; set; }
}

public class CategoryListItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}