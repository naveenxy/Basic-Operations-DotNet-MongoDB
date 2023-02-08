using Basic_Operations.Models;
using Basic_Operations.RepositoryContract;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Xml.Linq;

namespace Basic_Operations.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public EmployeeRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _employeeCollection = database.GetCollection<Employee>(mongoDBSettings.Value.CollectionName);
        }

        public async Task InsertOne(Employee employee)
        {
            if (employee !=null)
            _employeeCollection.InsertOne(employee);
        }

        public async Task<List<Employee>> GetAsync()
        {
            return await _employeeCollection.Find(new BsonDocument()).ToListAsync();
        }
       public async  Task<Employee> UpdateOne(string id, Employee employee)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
          
            var result = _employeeCollection.FindOneAndReplace(filter,employee);
            return result;
        }

        public async Task DeleteOne(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
            await  _employeeCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
