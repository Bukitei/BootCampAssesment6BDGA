using Assesment6DotNET.Interfaces;
using Assesment6DotNET.Models;
using Assesment6DotNET.MySQL;
using Dapper;
using MySql.Data.MySqlClient;

namespace Assesment6DotNET.Repositories
{
    public class OportunityRepository : OportunityInterface
    {
        private readonly MySQLConfiguration _connectionString;
        //Stablish the initial configuration of the connection with the database.
        public OportunityRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionString = mySQLConfiguration;
        }

        //Stablish the connection with the database when the app is up.
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //Get all the repositories from the database
        public Task<IEnumerable<Oportunity>> GetAllOportunities()
        {
            var db = dbConnection();
            string sql = @"SELECT * FROM oportunity;";
            return db.QueryAsync<Oportunity>(sql, new { });
        }

        public Task<Oportunity> GetOportunitiesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Oportunity> AddOportunity(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Oportunity> UpdateOportunity(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Oportunity> DeleteOportunity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
