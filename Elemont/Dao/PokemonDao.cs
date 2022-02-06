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
                "SET dbo.Pokemon.name = N'{0}' " +
                "WHERE pokemonId = N'{1}'", pokemon.Name, pokemon.PokemonId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool RemovePokemonbyId(int pokemonId)
        {
            string query = String.Format("DELETE FROM dbo.Pokemon WHERE dbo.Pokemon.pokemonId =" +
              "N'{0}'", pokemonId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool updateexp(Pokemon poke, int exp)
        {
            string query = String.Format("UPDATE dbo.Pokemon " +
                "SET dbo.Pokemon.exp = N'{0}' " +
                "WHERE PokemonId = N'{1}'", exp, poke.PokemonId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
