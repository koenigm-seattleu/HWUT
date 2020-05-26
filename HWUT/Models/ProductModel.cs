using System.Text.Json.Serialization;
using System.Text.Json;

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
        public string Date { get; set; }

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
    }
}