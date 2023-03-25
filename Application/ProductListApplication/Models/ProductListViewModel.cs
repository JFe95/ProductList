using Microsoft.AspNetCore.Mvc.Rendering;
using ProductListService.Entities;

namespace ProductListApplication.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products;

        public List<SelectListItem> SortListItems = new()
        {
            new SelectListItem { Text = "Default", Value = "Default" },
            new SelectListItem { Text = "Price", Value = "Price" },
            new SelectListItem { Text = "Views", Value = "ViewCount" }
        };

        public string SelectedItem;
    }
}
