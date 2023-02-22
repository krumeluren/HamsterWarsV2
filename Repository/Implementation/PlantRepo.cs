
using Core.Contracts.Repo.Contracts;
using Core.Domain.Entities.Models;

namespace Infrastructure.Repository.Implementation;

public class PlantRepo : RepoBase<Plant>, IPlantRepo
{
    public PlantRepo(RepoContext context) : base(context)
    {
    }
}

