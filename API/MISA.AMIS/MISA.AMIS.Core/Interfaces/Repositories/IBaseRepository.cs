using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface Base Repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: LMDuc (17/05/2021)
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        #region Lấy toàn bộ dữ liệu trong bảng
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>
        /// Danh sách các bản ghi
        /// </returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public IEnumerable<MISAEntity> GetAll();
        #endregion
        #region Lấy dữ liệu theo id
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public MISAEntity GetById(Guid entityId);
        #endregion
        #region Thêm dữ liệu
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public int Insert(MISAEntity entity);
        #endregion
        #region Cập nhật dữ liệu
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public int Update(Guid entityId, MISAEntity entity);
        #endregion
        #region Xóa bản ghi theo id
        /// <summary>
        /// Xóa bảng ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public int Delete(Guid entityId);
        #endregion
        #region Phân trang đối tượng
        /// <summary>
        /// Phân trang đối tượng.
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang.</param>
        /// <param name="pageIndex">Trang số bao nhiêu.</param>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// CreatedBy: LMDuc (17/05/2021)
        public IEnumerable<MISAEntity> GetMISAEntities(int pageSize, int pageIndex); 
        #endregion
    }
}

