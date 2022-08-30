using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pms.Employees.ServiceLayer.Files
{
    public class EmployeeImporter : IImportEmployeeService
    {
        public IEnumerable<IBankInformation> StartImport(string fileName)
        {
            IWorkbook nWorkbook;
            using (var nTemplateFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                nWorkbook = new HSSFWorkbook(nTemplateFile);
            HSSFFormulaEvaluator formulator = new HSSFFormulaEvaluator(nWorkbook);
            ISheet nSheet = nWorkbook.GetSheetAt(0);

            List<IBankInformation> employeeBankInformations = new();
            int i = 1;
            while (i <= nSheet.LastRowNum)
            {
                IRow row = nSheet.GetRow(i);
                if (ValidateRow(row) == false) break;

                IBankInformation bankInfo = new Employee();
                bankInfo.EEId = row.GetCell(0).GetValue(formulator);
                bankInfo.CardNumber = row.GetCell(6).GetValue(formulator);
                bankInfo.AccountNumber = row.GetCell(7).GetValue(formulator);
                bankInfo.BankName = row.GetCell(8).GetValue(formulator);

                employeeBankInformations.Add(bankInfo);
                i++;
            }

            return employeeBankInformations;
        }
        private bool ValidateRow(IRow row)
        {
            if (row is null) return false;

            ICell cell = row.GetCell(0);
            if (cell is null) return false;
            if (cell.StringCellValue == string.Empty) return false;
            if (cell.StringCellValue.Trim().Length != 4) return false;

            return true;
        }
    }
}
