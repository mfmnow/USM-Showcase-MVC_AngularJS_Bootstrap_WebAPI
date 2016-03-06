using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace USM.DAL.Models
{
    //[DataContract]
    public class User : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [Key]
        public int UserID { get; set; }
        [Required]
        [Icon("user")]
        public string Username { get; set; }
        [Icon("asterisk")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Icon(" email-icon")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [DefaultValue(UserStatus.Enabled)]
        [DisplayName("User Status")]
        [DisplayAsRadio(name1:"Enabled",value1:"1",name2:"Disabled",value2:"0")]
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public UserStatus UserIsDisabled { get; set; }
        
        [Required]
        [DisplayName("Role")]
        public virtual int RoleID { get; set;}
        //[NotMapped]
        //public string RoleName { get { return  } }
        [ForeignKey("RoleID")]
        //[JsonIgnore]
        public UserRole UserRole { get; set; }
    }

    public enum UserStatus
    {
        Enabled=0,
        Disabled=1
    }
}
