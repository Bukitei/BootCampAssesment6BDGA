using Assesment6DotNET.Interfaces;
using Assesment6DotNET.Models;
using Assesment6DotNET.MySQL;
using Dapper;
using MySql.Data.MySqlClient;

namespace Assesment6DotNET.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ContactRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionString = mySQLConfiguration;
        }
        

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public Task<Contact> AddContact(Contact contact)
        {
            /*var db = dbConnection();
            var sql = @"INSERT INTO contact (name, surname, details, isClient) VALUES (@Name, @Surname, @Details, @IsClient);";
            return db.ExecuteAsync(sql, new {
                Name = contact.,
                Surname = contact.Surname,
                Details = contact.Details,
                IsClient = contact.IsClient
            });*/
            return null;
        }

        public Task<Contact> DeleteContact(int id)
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts";
            return db.QueryAsync<Contact>(sql, new { });
        }

        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts";
            return db.QueryAsync<Contact>(sql, new { });
        }

        public Task<Contact> GetContactById(int id)
        {
            /*var db = dbConnection();
            var sql = "SELECT * FROM contacts where id = @Id";
            return db.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });*/
            return null;
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
