using Dapper;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.AMIS.Infrastructure.Repository
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    /// CreatedBy: LMDuc (18/05/2021)
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region hàm Khởi tạo
        public EmployeeRepository()
        {

        }
        #endregion

        #region Các hàm chức năng
        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>
        /// true - mã bị trùng
        /// false - không bị trùng
        /// </returns>
        /// CreatedBy: LMDuc (11/05/2021)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("EmployeeCode", employeeCode);
                parameters.Add("EmployeeId", employeeId);
                // thực hiện query
                var result = dbConnection.QueryFirstOrDefault<bool>($"Proc_CheckEmployeeCodeExist", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Kiểm tra trùng CMTND
        /// </summary>
        /// <param name="identifyNumber">Số chứng minh thư</param>
        /// <returns>
        /// true - mã bị trùng
        /// false - không bị trùng
        /// </returns>
        /// CreatedBy: LMDuc (11/05/2021)
        public bool CheckIdentifyNumberExist(string identifyNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdentifyNumber", identifyNumber);
                // thực hiện query
                var result = dbConnection.QueryFirstOrDefault<bool>($"Proc_CheckIdentifyNumberExist", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Kiểm tra trùng số điện thoại
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>
        /// true - mã bị trùng
        /// false - không bị trùng
        /// </returns>
        /// CreatedBy: LMDuc(11/05/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("PhoneNumber", phoneNumber);
                // thực hiện query
                var result = dbConnection.QueryFirstOrDefault<bool>($"Proc_CheckPhoneNumberExist", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageSize">số lượng bản ghi trong trang</param>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="filter">lọc chuỗi</param>
        /// <returns>
        /// Danh sách bản ghi
        /// </returns>
        /// CreatedBy: LMDuc (11/05/2021)
        public Pagging<Employee> GetEmployees(int pageSize, int pageIndex, string filter)
        {
            //Khởi tạo trang
            var res = new Pagging<Employee>()
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@filter", filter);
                // Tính tổng nhân viên.
                int? totalRecord = dbConnection.QueryFirstOrDefault<int>("Proc_GetTotalEmployees", parameters, commandType: CommandType.StoredProcedure);
                if (totalRecord == null)
                {
                    return res;
                }
                res.TotalRecord = totalRecord;
                // Lấy danh sách nhân viên.
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageIndex", pageIndex);
                dynamicParameters.Add("@pageSize", pageSize);
                dynamicParameters.Add("@filter", filter);
                var employees = dbConnection.Query<Employee>("Proc_GetEmployeeFilter", dynamicParameters, commandType: CommandType.StoredProcedure);
                res.Data = employees;
                return res;
            }

        }

        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: LMDuc (11/05/2021)
        public string GetMaxEmployeeCode()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // thực hiện query
                var result = dbConnection.QueryFirstOrDefault<string>($"Proc_GetMaxEmployeeCode", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        #endregion

    }
}
