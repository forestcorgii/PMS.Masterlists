using Payroll.Employees.Domain;
using Payroll.Employees.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.Concrete
{
    public class DetailEmployeeService
    {

        private EmployeeDbContext Context;
        public DetailEmployeeService(EmployeeDbContext context) =>
            Context = context;

        public Employee? GetEmployeeById(string EEId) => 
            Context.Employees
                .Where(ee => ee.EEId == EEId)
                .FirstOrDefault();

        //public async Task<List<Employee>?> CompleteEmployeeDetails(Timesheet[] unconfirmedTimesheet)
        //{
        //    if (HRMSService is not null)
        //    {
        //        List<Employee> employees = new();
        //        for (int i = 0; i <= unconfirmedTimesheet.Length - 1; i++)
        //        {
        //            string eeId = unconfirmedTimesheet[i].EEId;

        //            Employee? _employee = await FindAndSaveEE(eeId);

        //            if (_employee is not null)
        //                employees.Add(_employee);
        //        }
        //        return employees;
        //    }
        //    return null;
        //}

        //public async Task SupplyGovernmentDetailsAsync(string filepath)
        //{
        //    try
        //    {
        //        IWorkbook nWorkBook;
        //        using (var nNewPayreg = new FileStream(filepath, FileMode.Open, FileAccess.Read))
        //            nWorkBook = new HSSFWorkbook(nNewPayreg);

        //        ISheet nSheet = nWorkBook.GetSheetAt(0);
        //        IRow row = nSheet.GetRow(0);
        //        row.CreateCell(6).SetCellValue("TIN");
        //        row.CreateCell(7).SetCellValue("LASTNAME");
        //        row.CreateCell(8).SetCellValue("FIRSTNAME");
        //        row.CreateCell(9).SetCellValue("MIDDLENAME");
        //        row.CreateCell(10).SetCellValue("PAGIBIG");
        //        row.CreateCell(11).SetCellValue("PHILHEALTH");
        //        row.CreateCell(12).SetCellValue("BIRTHDATE");
        //        for (int i = 5, loopTo = nSheet.LastRowNum; i <= loopTo; i++)
        //        {
        //            row = nSheet.GetRow(i);
        //            if (row is not null && row.GetCell(1) is not null)
        //            {
        //                string eeid = row.GetCell(1).StringCellValue;
        //                Employee? ee = await FindAndSaveEE(eeid);
        //                if (ee is not null)
        //                {
        //                    row.CreateCell(6).SetCellValue(ee.TIN.Replace("-", ""));
        //                    row.CreateCell(7).SetCellValue(ee.LastName);
        //                    row.CreateCell(8).SetCellValue(ee.FirstName);
        //                    row.CreateCell(9).SetCellValue(ee.MiddleName);
        //                    row.CreateCell(10).SetCellValue(ee.Pagibig.Replace("-", ""));
        //                    row.CreateCell(11).SetCellValue(ee.PhilHealth.Replace("-", ""));
        //                    row.CreateCell(12).SetCellValue(ee.BirthDate.ToString(@"MM/dd//yyyy"));
        //                }
        //            }
        //        }
        //        using (var nNewPayreg = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite))
        //            nWorkBook.Write(nNewPayreg);

        //        Context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

    }
}
