using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practice1.Models
{
    public class RandomsDescriptionViewModel
    {
        public List<Randoms>? RandomList { get; set; }
        public SelectList? Descriptions { get; set; }
        public string? RandomsDescription { get; set; }
        public string? SearchString { get; set; }
    }
}
