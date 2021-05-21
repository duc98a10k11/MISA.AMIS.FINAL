using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    /// <summary>
    /// dịch vụ khách hàng
    /// </summary>
    /// CreatedBy: LMDuc (18/05/2021)
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Khai báo biến
        IEmployeeRepository _employeeRepository;
        #endregion
        #region Hàm khởi tạo
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Các hàm chức năng
        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <returns>
        /// true - mã nhân viên đã có trong cơ sở dữ liệu
        /// false - không bi trùng
        /// </returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeCodeExist(employeeCode);
        }

        /// <summary>
        /// Export file excel
        /// </summary>
        /// <param name="pageSize">số lượng bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang</param>
        /// <param name="filter">lọc bằng chuỗi</param>
        /// <returns>stream</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public Stream ExportExcel()
        {
            //var res = _employeeRepository.GetEmployees(pageSize, pageIndex, filter);
            var res = _employeeRepository.GetAll();
            var list = res.ToList();
            var stream = new MemoryStream();
            using var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add(Properties.Resources.Export_file_name);

            // set độ rộng col
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 30;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 15;
            workSheet.Column(9).Width = 30;

            using (var range = workSheet.Cells["A1:I1"])
            {
                range.Merge = true;
                range.Value = Properties.Resources.Export_file_name;
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // style cho excel.
            workSheet.Cells[3, 1].Value = Properties.Resources.Export_cell_stt; //số thứ tự
            workSheet.Cells[3, 2].Value = Properties.Resources.Export_cell_EmployeeCode; // mã nhân viên
            workSheet.Cells[3, 3].Value = Properties.Resources.Export_cell_EmployeeName; // tên nhân viên
            workSheet.Cells[3, 4].Value = Properties.Resources.Export_cell_Gender; // Giới tính 
            workSheet.Cells[3, 5].Value = Properties.Resources.Export_cell_DateOfBirth;// "Ngày sinh";
            workSheet.Cells[3, 6].Value = Properties.Resources.Export_cell_EmployeePosition;// "Chức danh";
            workSheet.Cells[3, 7].Value = Properties.Resources.Export_cell_DepartmentId; //"Tên đơn vị";
            workSheet.Cells[3, 8].Value = Properties.Resources.Export_cell_BankAccountNumber; // "Số tài khoản";
            workSheet.Cells[3, 9].Value = Properties.Resources.Export_cell_BankName; // "Tên ngân hàng";

            using (var range = workSheet.Cells["A3:I3"])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.Font.Bold = true;
                range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }


            int i = 0;
            // đổ dữ liệu từ list vào.
            foreach (var e in list)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = e.EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = e.EmployeeName;
                workSheet.Cells[i + 4, 4].Value = e.Gender;
                workSheet.Cells[i + 4, 5].Value = e.DateOfBirth?.ToString("dd/MM/yyyy");
                workSheet.Cells[i + 4, 6].Value = e.EmployeePosition;
                workSheet.Cells[i + 4, 7].Value = e.DepartmentId;
                workSheet.Cells[i + 4, 8].Value = e.BankAccountNumber;
                workSheet.Cells[i + 4, 9].Value = e.BankName;

                using (var range = workSheet.Cells[i + 4, 1, i + 4, 9])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                i++;
            }

            package.Save();
            stream.Position = 0;
            return package.Stream;
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageSize">số bản ghi có trong trang</param>
        /// <param name="pageIndex">vị trí của trang</param>
        /// <param name="filter">lọc theo tên</param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public Pagging<Employee> GetEmployees(int pageSize, int pageIndex, string filter)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new EmployeeException(Properties.Resources.Msg_Param_Error);
            }
            return _employeeRepository.GetEmployees(pageSize, pageIndex, filter);
        }

        /// <summary>
        /// Lấy giá trị mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Giá trị mã nhân viên lớn nhất</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public string GetMaxEmployeeCode()
        {
            return _employeeRepository.GetMaxEmployeeCode();
        }

        /// <summary>
        /// validate dữ liệu: mã nhân viên, số chứng minh thư, số điện thoại
        /// </summary>
        /// <param name="employee">object nhân viên</param>
        /// CreatedBy: LMDuc (18/05/2021)
        protected override void CustomValidate(Employee employee)
        {

            // Check trùng mã code
            if (CheckEmployeeCodeExist(employee.EmployeeCode) == true)
            {
                throw new EmployeeException(Properties.Resources.Msg_Code_Exist);
            }

        }
        #endregion

    }
}
