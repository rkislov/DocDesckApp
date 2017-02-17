using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class Document
    {
        //ID
        public Guid Id { get; set; }
        [Display(Name = "Организация")]
        public Guid? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [Display(Name = "Номер")]
        public string Number { get; set; }
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Содержание")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        public string ShortText { get; set; }
        
        [Display(Name = "Коментарий")]
        [MaxLength(200, ErrorMessage = "Превышена максимальная длинна записи")]
        [Required]
        public string Comment { get; set; }
        [Display(Name = "Статус")]
        public int Status { get; set; }
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
        [Display(Name = "Кабинет")]
        public Guid? ActivId { get; set; }
        public Activ Activ { get; set; }
        [Display(Name = "Фаил")]
        
        public string File { get; set; }
        [Display(Name = "Тип документа")]
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? ExecutorID { get; set; }
        public User Executor { get; set; }
        public Guid LifecycleId { get; set; }
        public Lifecycle Lifecycle { get; set; }

    }
    //Перечисление для статуса документа
    public enum DocumentStatus
    {
        Open = 1,
        Distributed = 2,
        Processing = 3,
        Checking = 4,
        Closed = 5
    }
    //Перечисление для приоритета
    public enum DocumentProirity
    {
        Low = 1,
        Medium = 2,
        Hight = 3,
        Critical = 4
    }
}