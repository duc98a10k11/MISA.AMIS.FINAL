using MISA.AMIS.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    #region Thông tin nhân viên
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// CreatedBy: LMDuc (18/05/2021)
    public class Employee
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [MISARequired] // validate chuỗi rỗng
        [MISAMaxLength(20, msg: "")] // validate độ dài tối đa nhập vào
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [MISARequired] // validate chuỗi rỗng
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư/căn cước công dân
        /// </summary>

        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>

        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên vị trí, chức vụ
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// id phòng ban
        /// </summary>
        [MISARequired] // validate chuỗi rỗng
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// tên tỉnh thành phố ngân hàng trực thuộc
        /// </summary>
        public string BankProvinceName { get; set; }

        /// <summary>
        /// Điện thoại bàn
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    } 
    #endregion
}
