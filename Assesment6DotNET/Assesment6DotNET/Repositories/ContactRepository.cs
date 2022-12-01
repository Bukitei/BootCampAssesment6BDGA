using System.Xml.Linq;
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
            var db = dbConnection();
            string sql;
            //Obtain the id of the new type if it don't exist.
            if (contact.type.idType == null)
            {
                sql = @"INSERT INTO types (types_names) VALUES (@Name);
                        SELECT LAST_INSERT_ID();";
                int id = db.QueryFirstOrDefaultAsync<int>(sql, new { Name = contact.type.typeName }).Result;
                contact.type = new TypeData(id, contact.type.typeName);
            }
            //Obtain the id of the new oportunity if it don't exist.
            if(contact.oportunity.id == null)
            {

                sql = @"INSERT INTO oportunity (name, surname, details, isClient) VALUES (@Name, @Surname, @Details, @IsClient);
                        SELECT LAST_INSERT_ID();";
                int id = db.QueryFirstOrDefaultAsync<int>(sql, new { Name = contact.oportunity.name, Surname = contact.oportunity.surName, Details = contact.oportunity.details, IsClient = contact.oportunity.isClient }).Result;
                contact.oportunity = new Oportunity(id, contact.oportunity.name, contact.oportunity.surName, contact.oportunity.details, contact.oportunity.isClient ?? false);
            }
            //Insert the new contact.
            sql = @"INSERT INTO contacts (idOportunity, date, isAction, details, idtypes) VALUES (@Oportunity, @Date, @IsAction, @Details, @IdTypes);";
            return db.QueryFirstOrDefaultAsync<Contact>(sql, new
            {
                Oportunity = contact.oportunity.id,
                Date = contact.date,
                IsAction = contact.isAction,
                Details = contact.details,
                IdTypes = contact.type.idType
            });
        }

        //See if the contact already exists
        private bool ContactExists(int id)
        {
            throw new NotImplementedException();
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
