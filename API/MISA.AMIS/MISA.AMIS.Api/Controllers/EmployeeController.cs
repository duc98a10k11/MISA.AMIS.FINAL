using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        #region Khai báo biến
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository; 
        #endregion
        #region Hàm khởi tạo
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeRepository, employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        #endregion
        
        #region Các hàm chức năng
        /// <summary>
        /// Lấy ra EmployeeCode lớn nhất trong DB
        /// </summary>
        /// <returns>EmployeeCode</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        [HttpGet("employeeCode")]
        public IActionResult GetCode()
        {
            var employeeCode = _employeeRepository.GetMaxEmployeeCode();
            if (employeeCode != null)
            {
                return Ok(employeeCode);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy danh sách nhân viên có lọc
        /// </summary>
        /// <param name="pageSize">số lượng nhân viên / trang</param>
        /// <param name="pageIndex">trang số bao nhiêu</param>
        /// <param name="filter">chuỗi để lọc</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        [HttpGet("Filter")]
        public IActionResult GetEmployees([FromQuery] int pageSize, int pageIndex, string filter)
        {
            var res = _employeeService.GetEmployees(pageSize, pageIndex, filter);
            if (res.Data.Any() && res.TotalRecord != null)
            {
                return Ok(res);
            }
            return NoContent();
        }

        /// <summary>
        /// Xuất ra file excel
        /// </summary>
        /// <param name="pageSize">số bản ghi/trang</param>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="filter"></param>
        /// <returns>
        /// 200 - thành công
        /// 500 - lỗi server
        /// </returns>
        /// CreatedBy: LMDuc (18/05/2021)
        [HttpGet("ExportingExcel")]
        public IActionResult ExportingExcel()
        {
            var stream = _employeeService.ExportExcel();
            string excelName = $"Danh-sach-nhan-vien-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }  
        #endregion

    }
}
