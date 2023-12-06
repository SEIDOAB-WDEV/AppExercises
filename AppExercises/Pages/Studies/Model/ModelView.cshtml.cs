﻿using System;
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
        IQuoteService _service = null;
        ILogger<ModelViewModel> _logger = null;

        //public member becomes part of the Model in the Razor page
        public csFamousQuote Quote { get; set; }
        public string ErrorMessage { get; set; } = null;

        //Will execute on a Get request
        public IActionResult OnGet()
        {
            try
            {
                //Read a QueryParameter
                Guid _id = Guid.Parse(Request.Query["id"]);

                //Use the Service
                Quote = _service.ReadQuote(_id);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            return Page();
        }

        //Inject services just like in WebApi
        public ModelViewModel(IQuoteService service, ILogger<ModelViewModel> logger)
        {
            _logger = logger;
            _service = service;
        }
    }
}
