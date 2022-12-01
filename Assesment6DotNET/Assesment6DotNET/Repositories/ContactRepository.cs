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
        private readonly OportunityRepository opRepository;
        private readonly TypeRepository typeRepository;
        //Stablish the initial configuration of the connection with the database.
        public ContactRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionString = mySQLConfiguration;
            opRepository = new OportunityRepository(mySQLConfiguration);
            typeRepository = new TypeRepository(mySQLConfiguration);
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
                typeRepository.AddTypes(contact.type);
                contact.type = typeRepository.GetLastInsertedType().Result;
            }
            //Obtain the new oportunity if it doesn't exists previously.
            if(contact.oportunity.id == null)
            {
                opRepository.AddOportunity(contact.oportunity);
                contact.oportunity = opRepository.GetLastInsertedOportunity().Result;


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

        //Here we try to delete a contact
        public Task<Contact> DeleteContact(int id)
        {
            var db = dbConnection();
            if (ContactExist(id))
            {
                string sql = @"DELETE FROM contacts WHERE idcontacts = @Id;";
                return db.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });

            }
            else
            {
                return null;
            }
        }

        private bool ContactExist(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM contacts WHERE idcontacts = @Id;";
            var contact = db.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id }).Result;
            if (contact != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public Task<Contact> GetLastInsertedContact()
        {
            var db = dbConnection();
            var sql = "SELECT * FROM contacts ORDER BY idcontacts DESC LIMIT 1";
            return db.QueryFirstOrDefaultAsync<Contact>(sql, new { });
        }
    }
}
