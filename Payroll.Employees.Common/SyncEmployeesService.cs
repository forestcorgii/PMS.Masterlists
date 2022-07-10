using Microsoft.EntityFrameworkCore;
using Payroll.Employees.Domain;
using Payroll.Employees.Persistence;
using Payroll.Employees.ServiceLayer.Concrete;
using Payroll.Employees.ServiceLayer.HRMS.Adapter;
using Payroll.Employees.ServiceLayer.HRMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.Common.Services
{
    public class SyncEmployeesService
    {

        private FindEmployeeService FindEmployeeService;
        private DetailEmployeeService DetailEmployeeService;
        private SaveEmployeeService SaveEmployeeService;

        public SyncEmployeesService(EmployeeDbContext context,HRMSAdapter hrmsAdapter)
        {
            SaveEmployeeService = new(context);
            DetailEmployeeService = new(context);

            FindEmployeeService = new(hrmsAdapter);
        }


        public async Task<Employee?> SyncEmployeeAsync(Employee employee, string site = "MANILA")
        {
            Employee? employeeFound = await FindEmployeeService.GetEmployeeAsync(employee.EEId, site);
            if (employeeFound is null)
                employeeFound = await FindEmployeeService.GetEmployeeAsync(employee.EEId, "LEYTE");

            if (employeeFound is not null)
            {
                SaveEmployeeService.CreateOrEdit(employee);
                employee.Active = true;
            }
            else
                employee.Active = false;
            return employee;
        }

        public async Task<Employee?> SyncEmployeeAsync(string eeId, string site = "MANILA")
        {
            Employee? ee = DetailEmployeeService.GetEmployeeById(eeId);
            if (ee is null)
            {
                ee = await FindEmployeeService.GetEmployeeAsync(eeId, site);
                if (ee is null)
                    ee = await FindEmployeeService.GetEmployeeAsync(eeId, "LEYTE");
                
                if (ee is not null)
                    SaveEmployeeService.CreateOrEditAndSave(ee);
                else
                    return new Employee() { EEId = eeId };
            }
            return ee;
        }

        //public async Task<List<Employee>?> CompleteEmployeeDetails(Employee[] ids)
        //{
        //    List<Employee> employees = new();
        //    for (int i = 0; i <= ids.Length - 1; i++)
        //    {
        //        string eeId = ids[i].EEId;

        //        Employee? _employee = await SyncEmployeeAsync(eeId);

        //        if (_employee is not null)
        //            employees.Add(_employee);
        //    }
        //    return employees;
        //}

    }
}
