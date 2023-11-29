using EmployeeManagment.Data;
using EmployeeManagment.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Services;

public interface IEmployeeService
{
    Task<GetEmployeesResponse> GetEmployees();
}

public class EmployeeService : IEmployeeService
{
    private readonly IDbContextFactory<DataContext> _factory;

    public EmployeeService(IDbContextFactory<DataContext> factory)
    {
        _factory = factory;
    }


    public Task<GetEmployeesResponse> GetEmployees()
    {
        throw new NotImplementedException();
    }
}
    
