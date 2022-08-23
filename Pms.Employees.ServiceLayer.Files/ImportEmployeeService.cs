using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pms.Employees.ServiceLayer.Files
{
    public class ImportEmployeeService : IImportEmployeeService
    {
        public IEnumerable<IBankInformation> StartImport(string fileName, string bankName)
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
                if (row is null || row.GetCell(0) is null) break; ;
                
                IBankInformation bankInfo = new Employee();
                bankInfo.EEId = row.GetCell(0).GetValue(formulator);
                bankInfo.CardNumber = row.GetCell(6).GetValue(formulator);
                bankInfo.AccountNumber = row.GetCell(7).GetValue(formulator);
                bankInfo.BankName = bankName;
                
                employeeBankInformations.Add(bankInfo);
                i++;
            }

            return employeeBankInformations;
        }
    }
}
