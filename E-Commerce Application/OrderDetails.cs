using System;
using System.Security.Cryptography;

namespace E_Commerce_Application

{
      /// <summary>
      /// Used to select a order's status information
      /// </summary>
     public enum OrderStatus{Default,Ordered,Cancelled}

     /// <summary>
     /// class <see cref="OrderDetails"/> used to collect order's details for maintain the order history
     /// </summary>
    public class OrderDetails
    {
        
        //static field for order id
        /// <summary>
        /// static field used to auto increament and it uniquely  identify an instance of
        /// </summary>
        private static int s_OrderId =1000;
      
          /// <summary>
          ///  property OrderId used to uniquely identify a <see cref="OrderDetails"/> class' object
          /// </summary>
          /// <value>It Allows only string type data</value>
          public string OrderId {get; set;}

          /// <summary>
          /// property customer Id used to provide a customer's ID
          /// </summary>
          /// <value>It Allows only string type data</value>
          public string CustomerId {get; set;}

          /// <summary>
          /// property ProductId used to provide a Product id of a each product
          /// </summary>
          /// <value>It Allows only string type data</value>
          public string ProductId {get; set;}

          /// <summary>
          /// property TotalPrice used to provide a total price of the particular product
          /// </summary>
          /// <value>It Allows only double type data</value>
          public double TotalPrice {get; set;}

          /// <summary>
          /// property PurchaseDate used to provide a Purchased date of the product
          /// </summary>
          /// <value>It Allows only Datetime type data</value>
          public DateTime PurchaseDate {get; set;}

          /// <summary>
          /// property Quantity used to provide a quantities of a order
          /// </summary>
          /// <value>It Allows only integer type data</value>
          public int Quantity {get; set;}

          /// <summary>
          /// property OrderStatus used to provide a status of a order
          /// </summary>
          /// <value>It Allows only Enum(Orderstatus) type data</value>
          public OrderStatus OrderStatus {get; set;}


          /// <summary>
          /// Constructor of <see cref="OrderDetails"/> class used to intialize values to its properties
          /// </summary>
          /// <param name="customerId">parameter customerId used to initialize customer's Id to the CustomerId property</param>
          /// <param name="productId">parameter customerId used to initialize customer's Id to the CustomerId property</param>
          /// <param name="totalPrice">parameter customerId used to initialize customer's Id to the CustomerId property</param>
          /// <param name="purchaseDate">parameter customerId used to initialize customer's Id to the CustomerId property</param>
          /// <param name="quantity">parameter customerId used to initialize customer's Id to the CustomerId property</param>
          /// <param name="orderStatus">parameter customerId used to initialize customer's Id to the CustomerId property</param> <summary>
        
          public OrderDetails(string customerId,string productId,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus){
           
            s_OrderId++;
            OrderId="OID"+s_OrderId;
            CustomerId = customerId;
            ProductId = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity =quantity;
            OrderStatus = orderStatus;
          }


    }
}
