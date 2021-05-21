using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Services
{
    /// <summary>
    /// interface Employee repository
    /// </summary>
    ///CreatedBy: LMDuc (18/05/2021)
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region interface Employee service
        /// <summary>
        /// Lấy giá trị mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Giá trị mã nhân viên lớn nhất</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public string GetMaxEmployeeCode();

        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <returns>
        /// true - mã nhân viên đã có trong cơ sở dữ liệu
        /// false - không bi trùng
        /// </returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public bool CheckEmployeeCodeExist(string employeeCode);

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageSize">số bản ghi</param>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="filter"></param>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public Pagging<Employee> GetEmployees(int pageSize, int pageIndex, string filter);

        /// <summary>
        /// Export file excel
        /// </summary>
        /// <param name="pageSize">số lượng bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang</param>
        /// <param name="filter">lọc bằng chuỗi</param>
        /// <returns>stream</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public Stream ExportExcel();
        #endregion
    }
}
