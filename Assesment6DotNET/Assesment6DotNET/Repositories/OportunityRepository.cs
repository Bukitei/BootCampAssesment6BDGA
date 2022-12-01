using Assesment6DotNET.Interfaces;
using Assesment6DotNET.Models;
using Assesment6DotNET.MySQL;
using Dapper;
using MySql.Data.MySqlClient;

namespace Assesment6DotNET.Repositories
{
    public class OportunityRepository : IOportunityRepository
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

        //Get a specific oportunity from the database by the id
        public Task<Oportunity> GetOportunitiesById(int id)
        {
            var db = dbConnection();
            var sql = "SELECT * FROM oportunity where idOportunity = @Id";
            return db.QueryFirstOrDefaultAsync<Oportunity>(sql, new { Id = id });
        }

        //Add a new oportunity into the database
        public Task<Oportunity> AddOportunity(Oportunity oportunity)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO oportunity (name, surname, details, isClient) 
                        VALUES (@Name, @Surname, @Details, @IsClient);";
            return db.QueryFirstOrDefaultAsync<Oportunity>(sql, new { 
                Name = oportunity.name, 
                Surname = oportunity.surName, 
                Details = oportunity.details, 
                IsClient = oportunity.isClient 
            });
        }

        //Update a oportunity into the database
        public Task<Oportunity> UpdateOportunity(Oportunity oportunity)
        {
            var db = dbConnection();
            var sql = @"UPDATE oportunity SET name = @Name, surname = @Surname, 
                        details = @Details, isClient = @IsClient WHERE idOportunity = @Id;";
            return db.QueryFirstOrDefaultAsync<Oportunity>(sql, new
            {
                Name = oportunity.name,
                Surname = oportunity.surName,
                Details = oportunity.details,
                IsClient = oportunity.isClient,
                Id = oportunity.id
            });
        }

        //Delete a oportunity from the database
        public Task<Oportunity> DeleteOportunity(int id)
        {
            var db = dbConnection();
            if (OportunityExist(id))
            {
                string sql = @"DELETE FROM oportunity WHERE idOportunity = @Id;";
                return db.QueryFirstOrDefaultAsync<Oportunity>(sql, new { Id = id });

            }
            else
            {
                return null;
            }
        }

        private bool OportunityExist(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM oportunity WHERE idOportunity = @Id;";
            var oportunity = db.QueryFirstOrDefaultAsync<Oportunity>(sql, 
                            new { Id = id }).Result;
            if (oportunity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
