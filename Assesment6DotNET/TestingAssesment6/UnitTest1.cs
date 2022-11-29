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
            connectionString = "Server=localhost;port=3306;database=assesment6db;uid=Badmin;password=R@ydr@g0n2";
        }
        //Testing that we can connect to the database and extract a data from contact.
        [Test]
        public void TestConnection()
        {
            ContactRepository contactRepository = new ContactRepository(new MySQLConfiguration(connectionString));
            var result = contactRepository.GetAllContacts();
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.Cast<Contact>().ElementAt(0).GetDetails());

            //Esto es el encoding para el login
            var messageBytes = Encoding.UTF8.GetBytes("password");

            Console.WriteLine(Convert.ToBase64String(messageBytes));
        }
    }
}