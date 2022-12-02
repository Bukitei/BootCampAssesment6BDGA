using Assesment6DotNET.MySQL;
using Assesment6DotNET.Repositories;
using Assesment6DotNET.Models;

namespace TestingAssesment6
{
    public class OportunityTest
    {
        String connectionString;
        [SetUp]
        public void Setup()
        {
            connectionString = "Server=localhost;port=3306;database=assesment6db;uid=Badmin;password=P@ssword123";
        }

        [Test]
        public void TestGetAllOportunities()
        {
            OportunityRepository oportunityRepository = new OportunityRepository(new MySQLConfiguration(connectionString));
            var result = oportunityRepository.GetAllOportunities();
            Assert.IsTrue(result.IsCompletedSuccessfully);
            for (int i = 0; i < result.Result.Count(); i++)
            {
                Console.WriteLine(result.Result.ElementAt(i).ToString());
            }
        }

        [Test]
        public void TestGetTheLastInsertedOportunity(){
            OportunityRepository oportunityRepository = new OportunityRepository(new MySQLConfiguration(connectionString));
            var result = oportunityRepository.GetLastInsertedOportunity();
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Console.WriteLine(result.Result.id);
        }
    }
}
