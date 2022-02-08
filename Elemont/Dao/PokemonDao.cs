using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class PokemonDao
    {
        private static PokemonDao instance;
        public static PokemonDao Instance
        {
            get
            {
                if (instance == null) instance = new PokemonDao();
                return instance;
            }
        }
        public Pokemon[] GetPokemonsByCellId(int cellId)
        {
            string query = String.Format("SELECT * From dbo.Pokemon WHERE dbo.Pokemon.cellId = " +
                 "N'{0}'", cellId);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Pokemon(item)).ToArray();
        }
        public Pokemon[] GetPokemonsByTrainerId(int trainerId)
        {
            string query = String.Format("SELECT * From dbo.Pokemon WHERE dbo.Pokemon.trainerId = " +
                 "N'{0}'", trainerId);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Pokemon(item)).ToArray();
        }
        public Pokemon GetPokemonById(int pokemonId)
        {
            string query = String.Format("SELECT * From dbo.Pokemon WHERE dbo.Pokemon.pokemonId = " +
                 "N'{0}'", pokemonId);
            return new Pokemon(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public bool MovePokemon(int pokemonId, int trainerId)
        {
            string query = String.Format("UPDATE dbo.Pokemon " +
                "SET dbo.Pokemon.trainerId = N'{0}', dbo.Pokemon.cellId = null " +
                "WHERE pokemonId = N'{1}'", trainerId, pokemonId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangePokemon(Pokemon pokemon)
        {
            string query = String.Format("UPDATE dbo.Pokemon " +
                "SET dbo.Pokemon.name = N'{0}', dbo.Pokemon.exp = N'{1}', dbo.Pokemon.speciesId =N'{2}', skill1Id = N'{3}', " +
                "skill2Id = N'{4}', cellId = N'{5}' " +               
                "WHERE pokemonId = N'{6}'", pokemon.Name,pokemon.Exp,pokemon.Species.SpeciesId,pokemon.Skill1.SkillId,
                pokemon.Skill2.SkillId,pokemon.CellId,pokemon.PokemonId) ;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool RemovePokemonbyId(int pokemonId)
        {
            string query = String.Format("DELETE FROM dbo.Pokemon WHERE dbo.Pokemon.pokemonId =" +
              "N'{0}'", pokemonId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool AddPokemon(Pokemon poke)
        {
            string query = String.Format("insert into Pokemon (name, speciesId, exp, cellId, skill1Id, skill2Id)" +
                "values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')"
                ,poke.Name,poke.Species.SpeciesId,poke.Exp,poke.CellId,poke.Skill1.SkillId,poke.Skill2.SkillId
                );            
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
