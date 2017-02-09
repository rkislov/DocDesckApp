using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class Activ
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Номер кабинета")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        public string CabNumber { get; set; }

        [Required]
        [Display(Name ="Отдел")]
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}