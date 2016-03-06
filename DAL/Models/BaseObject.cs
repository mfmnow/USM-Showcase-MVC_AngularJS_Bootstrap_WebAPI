using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace USM.DAL.Models
{
    public class BaseModel
    {
        [ScaffoldColumn(false)]
        public int IsDeleted { get; set; }
        [ScaffoldColumn(false)]
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get { return _createDate; } set { _createDate = value; } }
        [ScaffoldColumn(false)]
        private DateTime _lastUpdateDate = DateTime.Now;
        public DateTime LastUpdateDate { get { return _lastUpdateDate; } set { _lastUpdateDate = value; } }
        //[NotMapped]
        //public virtual string icon { get { return "justify"; } set{} }
    }
}
