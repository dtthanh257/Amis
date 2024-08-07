﻿using System;
using System.ComponentModel.DataAnnotations;
using MISA.WebFresher062023.Demo.Domain;

namespace MISA.WebFresher062023.Demo.Application
{
	public class EmployeeUpdateDto
    {
        [Required]
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string EmployeeCode { get; set; }

        [Required]
        [MaxLength(100)]
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string Fullname { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Gender Gender { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Guid DepartmentId { get; set; }
    }
}

