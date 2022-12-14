using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApp.Data.Enum;

namespace WebApp.ViewModels.Catalog.Card
{
    public class CardCreateRequest
    {
        public int AdminID { get; set; }
        [DisplayName("Mã thẻ cứng")]
        [Required(ErrorMessage = "Nhập mã thẻ cứng")]
        public string CardNumber { get; set; }
        public string SerialNumber { get; set; }
        public int Type { get; set; }
        public int ID { get; set; }
        public Status Status { get; set; }
        public Color Color { get; set; }
        public string Company { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int ControlType { get; set; }
        public int WorkType { get; set; }
        public int CardModelID { get; set; }
        public DateTime DeleteDate { get; set; }
        public int CardGUID { get; set; }
       
    }
}
