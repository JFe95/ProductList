using ProductListService.Entities;
using System.Net.Http.Headers;

namespace ProductListApplication.Services
{
    public static class ProductService
    {
        static HttpClient _client = new();
        private const string BaseAddress = "https://localhost:7088";

        public static async Task<List<Product>> GetProductsAsync()
        {
            var products = new List<Product>();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestUri = $"{BaseAddress}/productlist";
            var response = await _client.GetAsync(requestUri);

            if(response.IsSuccessStatusCode)
                products = await response.Content.ReadFromJsonAsync<List<Product>>();

            return products;
        }

        public static async Task ProductClickedAsync(Product product)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PutAsJsonAsync($"{BaseAddress}/updateviewcount/{product.ProductId}", product);
            response.EnsureSuccessStatusCode();
        }
    }
}
