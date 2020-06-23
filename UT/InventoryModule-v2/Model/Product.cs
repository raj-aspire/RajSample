using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModule_v2
{
    public class Product
    {
        #region Private Members
        private readonly IInventoryService _service;
        #endregion

        #region Constructor
        public Product(IInventoryService service)
        {
            _service = service;
        } 
        #endregion

        #region Instance Property
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockIn { get; set; }

        public int ReorderLevel { get; set; }
        #endregion

        #region Instance Method
        public bool IsStockAvailable(int productId, int quantity)
        {
            return _service.IsStockAvailable(productId, quantity);
        }

        public bool IsReorderLevelReached(int productId)
        {
            return _service.CheckReorderLevel(productId);
        }

        public Product Create()
        {
            return _service.CreateProduct(this);
        }

        public Product Update()
        {
            return _service.UpdateProduct(this.ProductId, this);
        }

        public bool Delete(int productId)
        {
            return _service.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            if (_service.GetProducts() == null || _service.GetProducts().Count < 0)
            {
                throw new ArgumentException("No products exists.");
            }

            return _service.GetProducts();
        }

        public Product GetProduct(int productId)
        {
            if (_service.GetProduct(productId) == null)
            {
                throw new ArgumentException("No product exist for product id : " + productId.ToString());
            }

            return _service.GetProduct(productId);
        } 
        #endregion
    }
}
