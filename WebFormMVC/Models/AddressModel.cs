using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFormMVC.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvaialableStates = new List<SelectListItem>();
        }

        [Display(Name="Country")]
        public int CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        public IList<SelectListItem> AvaialableStates { get; set; }
    }
}