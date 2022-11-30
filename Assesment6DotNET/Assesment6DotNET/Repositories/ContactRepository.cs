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
        //Stablish the initial configuration of the connection with the database.
        public ContactRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionString = mySQLConfiguration;
        }
        
        //Stablish the connection with the database when the app is up.
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //Add a new contact into the database
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

        //Here we try to delete a contact
        public Task<Contact> DeleteContact(int id)
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts";
            return null;
        }

        //Here we try to get all the contacts from the database
        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts";
            return db.QueryAsync<Contact>(sql, new { });
        }

        //Here we try to get a contact by its id
        public Task<Contact> GetContactById(int id)
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts where idcontacts = @Id";
            return db.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        //Here we try to update a contact
        public Task<Contact> UpdateContact(Contact contact)
        {
            var db = dbConnection();
            var sql = "UPDATE contacts SET idOportunity = @Oportunity, date = @Date, isAction = @isAction, details = @Details, idTypes = @IdTypes WHERE idcontacts = @Id";
            return db.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = contact.id, Oportunity = contact.oportunity.id, Date = contact.date, isAction = contact.isAction, Details = contact.details, IdTypes = contact.type.idType });
        }
    }
}
