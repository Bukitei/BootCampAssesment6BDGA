using System.Reflection.Metadata.Ecma335;
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
        public Task<TypeData> AddTypes(TypeData type)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO types (types_names) VALUES (@Name);";
            return db.QueryFirstOrDefaultAsync<TypeData>(sql, new { Name = type.typeName });
        }

        public Task<TypeData> DeleteTypes(int id)
        {
            var db = dbConnection();
            if (TypeExist(id))
            {
                string sql = @"DELETE FROM oportunity WHERE idOportunity = @Id;";
                return db.QueryFirstOrDefaultAsync<TypeData>(sql, new { Id = id });

            }
            else
            {
                return null;
            }
        }

        private bool TypeExist(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM types WHERE idtypes = @Id;";
            var type = db.QueryFirstOrDefaultAsync<TypeData>(sql,
                            new { Id = id }).Result;
            if (type != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<IEnumerable<TypeData>> GetAllTypes()
        {
            var db = dbConnection();
            string sql = @"SELECT * FROM types;";
            return db.QueryAsync<TypeData>(sql, new { });
        }

        public Task<TypeData> GetTypesById(int id)
        {
            var db = dbConnection();
            var sql = "SELECT * FROM types where idtypes = @Id";
            return db.QueryFirstOrDefaultAsync<TypeData>(sql, new { Id = id });
        }

        public Task<TypeData> UpdateTypes(TypeData type)
        {
            var db = dbConnection();
            var sql = @"UPDATE types SET typesname = @Name WHERE idtypes = @Id;";
            return db.QueryFirstOrDefaultAsync<TypeData>(sql, 
                new { Name = type.typeName, Id = type.idType });
        }

        public Task<TypeData> GetLastInsertedType()
        {
            var db = dbConnection();
            var sql = "SELECT * FROM types ORDER BY idtypes DESC LIMIT 1";
            return db.QueryFirstOrDefaultAsync<TypeData>(sql, new { });
        }
    }
}
