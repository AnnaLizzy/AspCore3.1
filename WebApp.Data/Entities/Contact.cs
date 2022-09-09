using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.Enum;

namespace WebApp.Data.Entities
{
    public class Contact
    {
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

        public Status Status { set; get; }
    }
}
