using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class TrainerRepository : GenericRepository<TrainerEntity>, ITrainerRepository
    {
        private readonly DbSet<TrainerEntity> _dataset;

        public TrainerRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<TrainerEntity>();
        }
    }
}
