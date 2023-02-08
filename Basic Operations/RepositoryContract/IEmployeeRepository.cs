using Basic_Operations.Models;

namespace Basic_Operations.RepositoryContract
{
    public interface IEmployeeRepository
    {

        Task InsertOne(Employee employee);
        Task<List<Employee>> GetAsync();
        Task<Employee> UpdateOne(string id, Employee employee);
        Task DeleteOne(string id);
    }
}
