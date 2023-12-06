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
    //Demonstrate how to use the model to present a list of objects
    public class PaginationModel : PageModel
    {
        //Just like for WebApi
        IMixedListService _service = null;
        ILogger<PaginationModel> _logger = null;

        //public member becomes part of the Model in the Razor page

        //Pagination
        public int NrOfPages { get; set; }
        public int PageSize { get; } = 5;

        public int ThisPageNr { get; set; } = 0;
        public int PrevPageNr { get; set; } = 0;
        public int NextPageNr { get; set; } = 0;
        public int PresentPages { get; set; } = 0;



        //Will execute on a Get request
        public IActionResult OnGet()
        {
            //Read a QueryParameter
            if (int.TryParse(Request.Query["pagenr"], out int _pagenr))
            {
                ThisPageNr = _pagenr;
            }


            return Page();
        }

        //Inject services just like in WebApi
        public PaginationModel(IMixedListService service, ILogger<PaginationModel> logger)
        {
            _logger = logger;
            _service = service;
        }
    }
}
