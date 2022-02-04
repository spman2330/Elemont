﻿using System;
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
    }
}
