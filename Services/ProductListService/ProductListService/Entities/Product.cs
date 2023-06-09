﻿namespace ProductListService.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool Priority { get; set; }
        public string Url { get; set; }
        public int ViewCount { get; set; }
    }
}
