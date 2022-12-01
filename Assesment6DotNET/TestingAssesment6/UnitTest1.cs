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
        //Test the GetAllContact that is in the ContactRepository class
        [Test]
        public void TestGetAllContacts()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            var result = contactRepository.GetAllContacts();
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.Count());
        }
        //Test the GetContactByID that is in the ContactRepository class
        [Test]
        public void TestGetContactById()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            var result = contactRepository.GetContactById(2);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.details);
        }
        //Test the AddContact that is in the ContactRepository class
        [Test]
        public void TestAddContact_Without_NewType_And_NewOportunity()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, 1, "contacto de prueba desde .net", 1);
            var result = contactRepository.AddContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }

        [Test]
        public void TestAddContact_Without_Type_But_With_Oportunity()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, 2, "contacto de prueba desde .net", new Oportunity("Carlos", "Rodriguez", "Un random de ejemplo", false));
            var result = contactRepository.AddContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }

        [Test]
        public void TestAddContact_With_Type_But_Without_Oportunity()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, new TypeData("prueba.net"), "contacto de prueba desde .net", 3);
            var result = contactRepository.AddContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }

        [Test]
        public void TestAddContact_With_Type_And_Oportunity()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(Convert.ToDateTime("2022-01-02"), false, new TypeData("pruebanet2"), "contacto de prueba desde .net", new Oportunity("Carla", "Rodriguez", "Una random de ejemplo", false));
            var result = contactRepository.AddContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }

        //Test the function UpdateContact that is in the ContactRepository class.
        [Test]
        public void TestUpdateContact()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            Contact contact = new Contact(2, 1, Convert.ToDateTime("2022-01-02"), false, "Esto es un update de .net", 1);
            var result = contactRepository.UpdateContact(contact);
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result);
        }
    }
}