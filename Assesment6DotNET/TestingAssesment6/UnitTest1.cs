using Assesment6DotNET.Repositories;
using Assesment6DotNET.MySQL;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Assesment6DotNET.Models;
using System.Text;

namespace TestingAssesment6
{
    public class Tests
    {
        String connectionString;
        [SetUp]
        public void Setup()
        {
            connectionString = "Server=localhost;port=3306;database=assesment6db;uid=Badmin;password=P@ssword123";
        }
        //Testing that we can connect to the database and extract a data from contact.
        [Test]
        public void TestGetAllContacts()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            var result = contactRepository.GetAllContacts();
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.Count());
        }

        [Test]
        public void TestGetContactById()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            var result = contactRepository.GetContactById(1);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.details);
            Console.WriteLine(Convert.ToDateTime("2022-01-02"));
        }
        [Test]
        public void TestAddContact()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, 1, "contacto de prueba desde .net", 1);
            var result = contactRepository.AddContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }

        [Test]
        public void TestUpdateContact()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, 1, "contacto de prueba desde .net", 1);
            var result = contactRepository.UpdateContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }
    }
}