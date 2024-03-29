﻿using System.Collections.Generic;

namespace Glosserie.API.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string name);
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void DeleteData(string storedProcedure, object parameters, string connectionStringName);
    }
}