using System;

namespace E_Commerce_Application
{

      /// <summary>
     /// class <see cref="ProductDetails"/> used to display product's details for purchase
     /// </summary>
    public class ProductDeatils
    {
             /// <summary>
            /// static field used to auto increament and it uniquely  identify an instance of
            /// <value></value> 
    
        // static field for ProductId 
        private static int s_ProductId =2000;
        
            /// <summary>
            /// Product Id  used to provide a Unique id for a product
            /// </summary>
            /// <value></value>
            public string ProductId {get; set;}

            /// <summary>
            /// Product Name used to provide a name of a product
            /// </summary>
            /// <value></value>
            public string ProductName {get; set;}

            /// <summary>
            /// STOCK used to provide a Stocks of a order
            /// </summary>
            /// <value></value>
            public int Stock {get; set;}

            /// <summary>
            /// price used to provide a price of a order
            /// </summary>
            /// <value></value>
            public double Price {get; set;}

            /// <summary>
            /// shippingDuration used to provide a duration of a shipping
            /// </summary>
            /// <value></value>
            public int ShippingDuration {get; set;}

            /// <summary>
            /// Constructor of <see cref="OrderDetails"/> class used to intialize values to its properties
            /// </summary>
            /// <param name="productName">parameter productName used to initialize Product's name to the property</param>
            /// <param name="stock">parameter stock used to initialize product's stock to the stock property</param>
            /// <param name="price">parameter price used to initialize product's price to the price property</param>
            /// <param name="shippingDuration">parameter shippingDuration used to initialize product's shipingDuration to the property</param>

            public ProductDeatils(string productName,int stock,double price,int shippingDuration) {
                s_ProductId++;
                ProductId = "PID" +s_ProductId;
                ProductName = productName;
                Stock = stock;
                Price =price;
                ShippingDuration = shippingDuration;
            }

            

    }
}
