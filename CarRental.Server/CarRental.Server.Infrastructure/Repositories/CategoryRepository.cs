using CarRental.Server.Domain.Cars;
using CarRental.Server.Infrastructure.Contexts;
using Nlabs.GenericRepository;

namespace CarRental.Server.Infrastructure.Repositories;
internal sealed class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
