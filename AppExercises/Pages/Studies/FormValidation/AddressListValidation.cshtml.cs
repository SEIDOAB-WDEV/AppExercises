using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudies.Pages;
using AppStudies.SeidoHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace AppExercises.Pages.Studies.FormEdit
{
	public class AddressListValidationModel : PageModel
    {
        //Just like for WebApi
        IMixedListService _service = null;
        ILogger<AddressListValidationModel> _logger = null;

        [BindProperty]
        public List<csAddressIM> AddressesIM { get; set; }

        //For Validation
        public reModelValidationResult ValidationResult { get; set; } = new reModelValidationResult(false, null, null);

        #region HTTP Requests
        public IActionResult OnGet()
        {
            AddressesIM = _service.Addresses.Take(5).Select(q => new csAddressIM(q)).ToList();
            return Page();
        }

        public IActionResult OnPostEdit(Guid addressId)
        {
            //Set the Address as Modified, it will later be updated in the database
            var q = AddressesIM.First(q => q.AddressId == addressId);

            if (q.StatusIM != enStatusIM.Inserted)
            {
                q.StatusIM = enStatusIM.Modified;
            }

            //Implement the changes
            q.StreetAddress = q.editStreetAddress;
            q.ZipCode = q.editZipCode;
            q.City = q.editCity;
            q.Country = q.editCountry;

            return Page();
        }

        public IActionResult OnPostUndo()
        {
            AddressesIM = _service.Addresses.Take(5).Select(q => new csAddressIM(q)).ToList();
            return Page();
        }

        public IActionResult OnPostSave()
        {
            //Check if there are any modified quotes , if so update them in the database
            var _modyfies = AddressesIM.FindAll(a => (a.StatusIM == enStatusIM.Modified));
            foreach (var item in _modyfies)
            {
                //get model
                var model = _service.Addresses.First(q => q.AddressId == item.AddressId);

                //update the changes and save
                model = item.UpdateModel(model);
            }

            //Reload the InputModel
            AddressesIM = _service.Addresses.Take(5).Select(q => new csAddressIM(q)).ToList();
            return Page();
        }

        #endregion

        #region Constructors
        //Inject services just like in WebApi
        public AddressListValidationModel(IMixedListService service, ILogger<AddressListValidationModel> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        #region Input Model
        //InputModel (IM) is locally declared classes that contains ONLY the properties of the Model
        //that are bound to the <form> tag
        //EVERY property must be bound to an <input> tag in the <form>
        //These classes are in center of ModelBinding and Validation
        public enum enStatusIM { Unknown, Unchanged, Inserted, Modified, Deleted }

        public class csAddressIM
        {
            //Status and ID should be part of InputModel
            public enStatusIM StatusIM { get; set; }
            public Guid AddressId { get; init; } = Guid.NewGuid();

            //Properties from Model which is to be edited in the <form>
            public string StreetAddress { get; set; }
            public int ZipCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }

            //Added properites to edit in the list with undo
            public string editStreetAddress { get; set; }
            public int editZipCode { get; set; }
            public string editCity { get; set; }
            public string editCountry { get; set; }

            #region constructors and model update
            public csAddressIM() { StatusIM = enStatusIM.Unchanged; }

            //Copy constructor
            public csAddressIM(csAddressIM original)
            {
                StatusIM = original.StatusIM;
                AddressId = original.AddressId;

                StreetAddress = original.StreetAddress;
                ZipCode = original.ZipCode;
                City = original.City;
                Country = original.Country;

                editStreetAddress = original.editStreetAddress;
                editZipCode = original.editZipCode;
                editCity = original.editCity;
                editCountry = original.editCountry;
            }

            //Model => InputModel constructor
            public csAddressIM(csAddress original)
            {
                StatusIM = enStatusIM.Unchanged;
                AddressId = original.AddressId;

                StreetAddress = editStreetAddress = original.StreetAddress;
                ZipCode = editZipCode = original.ZipCode;
                City = editCity = original.City;
                Country = editCountry = original.Country;
            }

            //InputModel => Model
            public csAddress UpdateModel(csAddress model)
            {
                model.AddressId = AddressId;

                model.StreetAddress = StreetAddress;
                model.ZipCode = ZipCode;
                model.City = City;
                model.Country = Country;

                return model;
            }
            #endregion

        }
        #endregion
    }
}

//Exercise:
//1. Modify AddressListValidation.cshtml so it can write out ServerSide Validation Errors, if any
//2. Add ServerSide Validation when Editing an Address
//3. Include the necessary scripts for Client Side validation
//2. Add ClientSide Validation when Editing an Address