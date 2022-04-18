using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Meyer.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Indtast dit navn!")]
        [Display(Name = "Indtast navn: ")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Dit navn må maks være 20 bogstaver")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Indtast dit Username")]
        [Display(Name = "Indtast username: ")]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Dit navn må maks være 20 bogstaver, og minimum 6")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Indtast din email!")]
        [Display(Name = "Indtast email: ")]
        public string E_mail { get; set; }

        [Required(ErrorMessage = "Indtast dit password!")]
        [Display(Name = "Indtast password: ")]
        [DataType(DataType.Password)]
        //evt tilføj repeat password

        public string Password { get; set; }

    }
}