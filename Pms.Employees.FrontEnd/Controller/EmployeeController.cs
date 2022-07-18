using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.Concrete;
using Pms.Employees.ServiceLayer.HRMS.Adapter;
using Pms.Employees.ServiceLayer.HRMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.FrontEnd.Test.Controller
{
    public class EmployeeController
    {
        EmployeeDbContext Context;
        HRMSAdapter Adapter;

        public EmployeeController()
        {
            Context = new EmployeeDbContext();
            Adapter = HRMSAdapterFactory.CreateAdapter(Shared.Configuration);
        }


        public List<Employee> LoadEmployees()
        {
            var service = new ListEmployeesService(Context);
            return service.GetEmployees().ToList();
        }

        public async Task<Employee?> FindEmployeeAsync(string eeId)
        {
            var service = new FindEmployeeService(Adapter);
            Employee? employeeFound = await service.GetEmployeeAsync(eeId);
            if (employeeFound is not null)
                return employeeFound;

            return default;
        }

        public void SaveEmployee(Employee employee)
        {
            var service = new SaveEmployeeService(Context);
            service.CreateOrEditAndSave(employee);
        }
    }
}
