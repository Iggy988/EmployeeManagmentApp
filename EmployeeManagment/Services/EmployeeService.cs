﻿using EmployeeManagment.Data;
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


    public async Task<GetEmployeesResponse> GetEmployees()
    {
        var response = new GetEmployeesResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var employees = await context.Employees.ToListAsync();
                response.Employees = employees;
                response.StatusCode = 200;
                response.Message = "Success";
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error retrieving employees: "+ex.Message;
            response.Employees = null;
        }

        return response;
    }
}
    
