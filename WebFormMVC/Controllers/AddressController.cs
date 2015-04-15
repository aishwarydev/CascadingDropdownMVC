using RespositoryCountryState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFormMVC.Models;

namespace WebFormMVC.Controllers
{
    public class AddressController : Controller
    {
        private IAddressRepository _repository;

        public AddressController() : this(new AddressRepository())
        {

        }

        public AddressController(IAddressRepository repository)
        {
            _repository = new AddressRepository();
        }
        
        // GET: Address
        public ActionResult Index()
        {
            AddressModel model = new AddressModel();
            model.AvailableCountries.Add(new SelectListItem { Text = "--Please Select--", Value = "Select Items" });

            var Countries = _repository.GetAllCountries();
            foreach(var country in Countries)
            {
                model.AvailableCountries.Add(new SelectListItem(){Text=country.Name, Value=country.Id.ToString()});
            }
            

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name)
        {
            _repository.CreateCountry(Name);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetStatesbyCountryId(string CountryId)
        {
            if (String.IsNullOrEmpty(CountryId))
            {
                throw new ArgumentNullException("countryId");
            }

            int id=0;
            bool isValid=Int32.TryParse(CountryId,out id);


            return Json(_repository.GetAllStatesByCountryId(id).ToList().Select(x=>new KeyValuePair<int,string>(x.Id,x.Name)),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateState(string CountryId, string Name)
        {
            return View();
        }

    }
}