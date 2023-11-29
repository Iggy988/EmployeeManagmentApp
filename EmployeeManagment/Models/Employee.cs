﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public decimal Salary { get; set; }
    public EmployeeType Type { get; set; }
    public Position Position { get; set; }
}

public enum EmployeeType
{
    [Display(Name = "Freelance")]
    Freelance,
    [Display(Name = "Casual")]
    Casual,
    [Display(Name = "PartTime")]
    PartTime,
    [Display(Name = "FullTime")]
    FullTime

}

public enum Position
{
    [Display(Name = "CEO")]
    CEO,

    [Display(Name = "CFO")]
    CFO,

    [Display(Name = "CTO")]
    CTO,

    [Display(Name = "Accountant")]
    Accountant,

    [Display(Name = "HR Manager")]
    HRManager,

    [Display(Name = "Marketing Manager")]
    MarketingManager,

    [Display(Name = "Sales Manager")]
    SalesManager,

    [Display(Name = "Software Engineer")]
    SoftwareEngineer,

    [Display(Name = "Data Analyst")]
    DataAnalyst,

    [Display(Name = "Customer Support")]
    CustomerSupport
}