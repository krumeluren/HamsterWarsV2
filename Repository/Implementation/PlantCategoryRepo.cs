
using Core.Contracts.Repo.Contracts;
using Core.Domain.Entities.Models;

namespace Infrastructure.Repository.Implementation;

public class PlantCategoryRepo : RepoBase<Plant>, IPlantCategoryRepo
{
    public PlantCategoryRepo(RepoContext context) : base(context)
    {
    }
}

