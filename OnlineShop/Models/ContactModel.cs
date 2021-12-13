using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ContactModel
    {
        [Key]
        [Required(ErrorMessage = "Bạn phải nhập Name")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập Subject")]
        public string Content { set; get; }
    }
}