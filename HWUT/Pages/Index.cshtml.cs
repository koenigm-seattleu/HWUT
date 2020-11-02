using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HWUT.Models;
using HWUT.Services;

namespace HWUT.Pages
{
    /// <summary>
    /// The Main Index page for the site
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // The service that holds teh products
        public JsonFileProductService ProductService;
        
        // The Products to show
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Constructor takes the Logger, and the Json File Product Service 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// HTTP Get Response
        /// </summary>
        public void OnGet()
        {
            // Get the products
            Products = ProductService.GetProducts();

        }
    }
}