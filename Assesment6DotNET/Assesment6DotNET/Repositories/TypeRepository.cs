using Assesment6DotNET.Interfaces;
using Assesment6DotNET.Models;
using Assesment6DotNET.MySQL;
using Dapper;
using MySql.Data.MySqlClient;

namespace Assesment6DotNET.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public TypeRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionString = mySQLConfiguration;
        }

        //Stablish the connection with the database when the app is up.
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public Task<Oportunity> AddTypes(TypeData type)
        {
            throw new NotImplementedException();
        }

        public Task<Oportunity> DeleteTypes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Oportunity>> GetAllTypes()
        {
            var db = dbConnection();
            string sql = @"SELECT * FROM types;";
            return db.QueryAsync<Oportunity>(sql, new { });
        }

        public Task<Oportunity> GetTypesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Oportunity> UpdateTypes(TypeData type)
        {
            throw new NotImplementedException();
        }
    }
}
