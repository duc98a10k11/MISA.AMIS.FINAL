using MISA.AMIS.Core.AttributeCustom;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        #region Khai báo property
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion
        #region Khởi tạo
        //Contructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Các hàm 
        /// <summary>
        /// Xóa bản ghi theo id trong DB
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>số bản ghi được xóa</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        /// <summary>
        /// Lấy dữ liệu toàn bộ bản ghi trong DB
        /// </summary>
        /// <returns>danh sách dữ liệu các bản ghi</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy dữ liệu bản ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>dữ liệu của bản ghi</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi cần thêm</param>
        /// <returns>số bản ghi được thêm vào DB</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Insert(MISAEntity entity)
        {
            //validate dữ liệu
            Validate(entity);
            return _baseRepository.Insert(entity);
        }

        #region Validate dữ liệu
        /// <summary>
        /// validate dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu cần validate</param>
        /// CreatedBy: LMDuc (18/05/2021)
        private void Validate(MISAEntity entity)
        {
            //lấy ra tất cả các property của class:
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                var maxLengthProperties = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                if (requiredProperties.Length > 0)
                {
                    // lấy giá trị:
                    var propertyValue = property.GetValue(entity);
                    // kiểm tra giá trị
                    if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requiredProperties[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"{property.Name} " + Properties.Resources.Msg_Error_Requied;
                        }
                        throw new EmployeeException(msgError);
                    }
                }
                //check maxlength:
                if (maxLengthProperties.Length > 0)
                {
                    //lấy giá trị 
                    var propertyValue = property.GetValue(entity);
                    var maxLength = (maxLengthProperties[0] as MISAMaxLength).MaxLength;
                    // kiểm tra giá trị
                    if (propertyValue.ToString().Length > maxLength)
                    {

                        var msgError = $"{property.Name} " + Properties.Resources.Msg_Error_MaxLength + maxLength;
                        throw new EmployeeException(msgError);
                    }
                }
            }
            CustomValidate(entity);
        }

        /// <summary>
        /// validate dữ liệu dành cho các service con
        /// </summary>
        /// <param name="entity">object cần validate</param>
        /// CreatedBy: LMDuc (18/05/2021)
        protected virtual void CustomValidate(MISAEntity entity)
        {

        }
        #endregion

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">bản ghi cần cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public int Update(Guid entityId, MISAEntity entity)
        {
            return _baseRepository.Update(entityId, entity);
        }

        /// <summary>
        /// Phân trang đối tượng.
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang.</param>
        /// <param name="pageIndex">Trang số bao nhiêu.</param>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// CreatedBy: LMDuc (18/05/2021)
        public IEnumerable<MISAEntity> GetMISAEntities(int pageSize, int pageIndex)
        {
            return _baseRepository.GetMISAEntities(pageSize, pageIndex);
        }
        #endregion
    }
}
