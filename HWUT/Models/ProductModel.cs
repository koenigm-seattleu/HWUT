using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace HWUT.Models
{
    /// <summary>
    /// The Product Model
    /// </summary>
    public class ProductModel
    {
        // ID
        public string Id { get; set; }
        
        // Who Made It
        public string Maker { get; set; }

        // The Image
        [JsonPropertyName("img")]
        public string Image { get; set; }
        
        // URL to the item
        public string Url { get; set; }
        
        // Display Title
        public string Title { get; set; }
        
        // Display Descirption
        public string Description { get; set; }

        // Date String
        public DateTime Date { get; set; }

        // The Next Stop in this tour
        public string Sequence { get; set; }

        // Email
        public string Email { get; set; }

        // Logistics
        public string Logistics { get; set; }

        // Rating Array
        public int[] Ratings { get; set; }

        // Return the json version of the data
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        /// <summary>
        /// Create a new default Product
        /// 
        /// Set Date to be today
        /// Set Logistics to Empty
        /// Email to Unknown
        /// Initialize a rating to be 5 
        /// </summary>
        public ProductModel()
        {
            Date = DateTime.UtcNow;

            Logistics = "";

            Email = "Unknown";

            // Create an element in the array 
            Ratings = new int[] { 5 };
        }

        public int AverageRating()
        {
            if (Ratings == null)
            {
                return 0;
            }

            var total = 0;
            var count = 0;

            foreach (var item in Ratings)
            {
                total += item;
                count ++;
            }

            if (count == 0)
            {
                return 0;
            }

            if (total == 0)
            {
                return 0;
            }

            return total / count;
        }
    }
}