﻿using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.Models.DTOs;
using EmployeeManagment.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Services;

public interface IEmployeeService
{
    Task<GetEmployeesResponse> GetEmployees();
    Task<BaseResponse> AddEmployee(AddEmployeeForm form);
    Task<GetEmployeeResponse> GetEmployee(int id);  
    Task<BaseResponse> DeleteEmployee(Employee employee);  
    Task<BaseResponse> EditEmployee(Employee employee);  
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

    public async Task<BaseResponse> AddEmployee(AddEmployeeForm form)
    {
        var response = new BaseResponse();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Add(new Employee
                {
                    Name = form.Name,
                    Position = form.Position,
                    Salary = form.Salary,
                    Type = form.Type,
                    ImgUrl = form.ImgUrl
                });
                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee added successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occured while adding employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error adding employee: " + ex.Message;
        }

        return response;
    }

    public async Task<GetEmployeeResponse> GetEmployee(int id)
    {
        var response = new GetEmployeeResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var employee = await  context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                
                response.StatusCode = 200;
                response.Message = "Success";
                response.Employee = employee;
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error retrieving employee: " + ex.Message;
            response.Employee = null;
        }

        return response;
    }

    public async Task<BaseResponse> DeleteEmployee(Employee employee)
    {
        var response = new BaseResponse();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Remove(employee);

                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee deleted successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occured while deliting employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error deliting employee: " + ex.Message;
        }

        return response;
    }

    public async Task<BaseResponse> EditEmployee(Employee employee)
    {
        var response = new BaseResponse();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Update(employee);
                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee updated successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occured while updating employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error updating employee: " + ex.Message;
        }

        return response;
    }
}
    
