using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using Microsoft.AspNetCore.Hosting;

using HWUT.Models;

namespace HWUT.Services
{
    /// <summary>
    /// Service to retrieve the json data store and load ProductModel from it
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// Default Constructor
        /// Stands up with the web environment passed to it
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Returns the path to the wwwroot folder
        public IWebHostEnvironment WebHostEnvironment { get; }

        // The File Name for the json file
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Returns a list of the Product Models
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProducts()
        {
            // Open the file and load it
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add a Rating to the Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            // Write the updated json
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }
}