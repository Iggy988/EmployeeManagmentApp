﻿namespace EmployeeManagment.Models.Responses;

public class GetEmployeesResponse : BaseResponse
{
    public List<Employee>? Employees { get; set; }
}
