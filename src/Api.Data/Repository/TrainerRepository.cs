using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class TrainerRepository : GenericRepository<TrainerEntity>, ITrainerRepository
    {
        private readonly DbSet<TrainerEntity> _dataset;
        private readonly DbSet<PokemonEntity> _pokemonDataSet;

        public TrainerRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<TrainerEntity>();
            _pokemonDataSet = context.Set<PokemonEntity>();
        }


        public async Task<TrainerEntity> FindCompleteById(Guid id)
        {
            try
            {
                return await _dataset.Include(t => t.Pokemons).FirstOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<TrainerEntity> AddPokemonToPokedex(Guid id, PokemonEntity pokemon)
        {
            TrainerEntity trainerEntity;
            List<PokemonEntity> pokemonList;

            try
            {
                //trainerEntity = await _dataset.SingleOrDefaultAsync(t => t.Id.Equals(id));
                trainerEntity = await _dataset.Include(t => t.Pokemons).FirstOrDefaultAsync(t => t.Id.Equals(id));

                pokemonList = trainerEntity.Pokemons.ToList();
                pokemonList.Add(pokemon);
                trainerEntity.Pokemons = pokemonList;

                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }

            return trainerEntity;
        }
    }
}
