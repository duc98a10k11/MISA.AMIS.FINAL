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
    #region Phòng ban controller
    /// <summary>
    /// Phòng ban controler
    /// </summary>
    /// CreatedBy: LMDuc (18/05/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        IDepartmentService _departmentService;
        IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, IDepartmentService departmentService) : base(departmentRepository, departmentService)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }

    } 
    #endregion
}
