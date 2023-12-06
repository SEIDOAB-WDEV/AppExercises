using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Models;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Services;
using AppStudies.Pages;

namespace AppStudies.Pages
{
    //Demonstrate how to read Query parameters
    public class ModelViewModel : PageModel
    {
        //Just like for WebApi
        IMixedListService _service = null;
        ILogger<ModelViewModel> _logger = null;

        //public member becomes part of the Model in the Razor page

        //Method that will execute on a Get request

        //Inject services just like in WebApi
        public ModelViewModel(IMixedListService service, ILogger<ModelViewModel> logger)
        {
            _logger = logger;
            _service = service;
        }
    }
}
