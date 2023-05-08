using Ostral.Core.Services;

namespace Ostral.Core.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetCategoryById(string categoryId);
    Task<IEnumerable<CategoryDto>> GetAllCategories();
}