using Dapper;
using MISA.AMIS.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repository
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: LMDuc (18/05/2021)
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        #region khai báo biến
        //khai báo biến
        /// <summary>
        /// tên bảng
        /// </summary>
        string tableName = typeof(MISAEntity).Name;
        /// <summary>
        /// khai báo connectionString
        /// </summary>
        protected string connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database = MF819_AMIS_LMDuc;" +
            "User Id= dev;" +
            "Password = 12345678;Convert Zero Datetime=true;";
        /// <summary>
        /// dbConnection
        /// </summary>
        protected IDbConnection dbConnection;
        #endregion

        #region Các hàm chức năng
        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>số bản ghi được xóa</returns>
        /// CreatedBy: LMDuc (07/05/2021)
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", entityId);
                var rowsAffect = dbConnection.Execute($"Proc_Delete{tableName}", param: parameters,
                    commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi có trong bảng
        /// </summary>
        /// <returns>Danh sách dữ liệu các bản ghi</returns>
        /// CreatedBy: LMDuc (07/05/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // thực hiện query
                var result = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Lấy dữ liệu bản ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>dữ liệu bản ghi</returns>
        /// CreatedBy: LMDuc (07/05/2021)
        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var result = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById", param: parameters, commandType: CommandType.StoredProcedure);
                return result;

            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi</param>
        /// <returns>số bản ghi được thêm mới</returns>
        /// CreatedBy: LMDuc (07/05/2021)
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi</param>
        /// <returns>số bản ghi được cập nhật</returns>
        /// CreatedBy: LMDuc (07/05/2021)
        public int Update(Guid entityId, MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity,
                    commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        /// <summary>
        /// phân trang
        /// </summary>
        /// <param name="pageSize">số bản ghi trên 1 trang</param>
        /// <param name="pageIndex">vị trí của trang</param>
        /// <returns>
        /// Danh sách bản ghi
        /// </returns>
        /// CreatedBy: LMDuc (12/05/2021)
        public IEnumerable<MISAEntity> GetMISAEntities(int pageSize, int pageIndex)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowAffect = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}Filter",
                    commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }  
        #endregion

    }
}
