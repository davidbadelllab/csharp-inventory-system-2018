using System;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    /// <summary>
    /// Product Model
    /// C# 7.3 features demonstration
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // C# 7.3: Tuple return type
        public (string Status, int DaysUntilRestock) GetStockStatus()
        {
            if (Stock == 0)
                return ("Out of Stock", 7);
            else if (Stock < 10)
                return ("Low Stock", 3);
            else
                return ("In Stock", 0);
        }

        // C# 7.3: Expression variables
        public decimal GetDiscountedPrice(decimal discountPercent = 0)
        {
            var discount = Price * (discountPercent / 100);
            return Price - discount;
        }

        // C# 7.3: Ref returns and locals
        public ref readonly decimal GetPriceRef()
        {
            return ref Price;
        }

        // Event with attribute on backing field
        [field: NonSerialized]
        public event EventHandler StockUpdated;

        protected virtual void OnStockUpdated()
        {
            StockUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateStock(int newStock)
        {
            Stock = newStock;
            UpdatedAt = DateTime.Now;
            OnStockUpdated();
        }
    }

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
