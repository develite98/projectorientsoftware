using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class Users
    {

        public int userID { get; set; }

        [Required(ErrorMessage ="Please enter name.")]
        [DisplayName("User name")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string userPassword { get; set; }

        public string userImage { get; set; }

        public string userAddress { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        public int UserKind { get; set; }

    }
}
