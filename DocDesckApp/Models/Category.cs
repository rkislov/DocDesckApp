using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Тип документа")]
        [MaxLength(50, ErrorMessage ="Превышена максимальная длинна записи")]
        public string Name { get; set;}
    }
}