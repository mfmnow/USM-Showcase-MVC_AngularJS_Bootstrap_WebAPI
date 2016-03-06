using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace USM.DAL.Models
{
    [DisplayName("User Role")]
    public class UserRole : BaseModel
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Unique]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
