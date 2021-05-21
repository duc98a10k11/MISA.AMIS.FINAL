using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Services
{
    #region BaseInterface
    /// <summary>
    /// Interface Base Service
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: LMDuc (18/05/2021)
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>
        /// Danh sách các bản ghi
        /// </returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Insert(MISAEntity entity);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Update(Guid entityId, MISAEntity entity);
        /// <summary>
        /// Xóa bảng ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Delete(Guid entityId);
        /// <summary>
        /// Phân trang đối tượng.
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang.</param>
        /// <param name="pageIndex">Trang số bao nhiêu.</param>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public IEnumerable<MISAEntity> GetMISAEntities(int pageSize, int pageIndex);

    } 
    #endregion
}
