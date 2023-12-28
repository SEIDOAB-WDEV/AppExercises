using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudies.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace AppExercises.Pages.Studies.FormEdit
{
	public class AddressListModel : PageModel
    {
        //Just like for WebApi
        IMixedListService _service = null;
        ILogger<AddressListModel> _logger = null;

        [BindProperty]
        public List<csAddress> AddressesIM { get; set; }

        #region HTTP Requests
        public IActionResult OnGet()
        {
            AddressesIM = _service.Addresses.Take(5).ToList();
            return Page();
        }

        public IActionResult OnPostEdit(Guid addressId)
        {
            return Page();
        }

        public IActionResult OnPostUndo()
        {
            return Page();
        }

        public IActionResult OnPostSave()
        {
            return Page();
        }

        #endregion

        #region Constructors
        //Inject services just like in WebApi
        public AddressListModel(IMixedListService service, ILogger<AddressListModel> logger)
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
        }
        #endregion
    }
}

//Exercise:
//1. Complete the InputModel csAddressIM
//2. Modify so that the BindProperty is related to csAddressIM instead of csAddress
//3. Implement the collapsable Edit on a row so that each row can be edited independently
//4. Implement OnPostUndo so the Model is restored to its original shape
//5. Implement OnPostSave so the Model is updated