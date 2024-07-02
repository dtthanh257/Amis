using MISA.WebFresher062023.Demo.Domain;
using System;
using System.Reflection;

namespace MISA.WebFresher062023.Demo.Domain
{
    public class EmployeeEntity : BaseAuditEntity, TEntity<Guid>
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// mã nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string EmployeeCode { get; set; }

        /// <summary>
        /// họ và tên nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string Fullname { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính 0-nam, 1-nữ, 2-khác
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Gender Gender { get; set; }

        /// <summary>
        /// Id phòng làm việc
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? CreatedBy { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người modify
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// ngày modify
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public DateTime? ModifiedDate { get;set; }

        public Guid GetId()
        {
            return EmployeeId;
        }

        public void SetId(Guid id)
        {
            EmployeeId = id;
        }
    }

}