using System;

namespace OnlineMedicalStore
{ 
    // Enum for ordered status
    public enum OrderStatus{Default,Purchased,Cancelled}
    public class OrderDetails
    {
         
         // static field for order id
         private static int s_OrderId =1000;
           /* OrderID (Auto-increment – OID3000)
	         UserID
	          MedicineID
	           MedicineCount
	           TotalPrice
	           OrderDate
	            OrderStatus {Enum – Purchased, Cancelled} */

         //property 

         public string OrderId {get; set;}    
         public string UserId {get; set;}
         public string MedicineId {get; set;}
         public double TotalPrice {get; set;}

         public int MedicineCount {get; set;}
          public DateTime OrderDate  {get; set;}

         public OrderStatus StatusOfOrder {get; set;}

         public OrderDetails (string userId, string medicineId,int medicineCount,double totalPrice,DateTime orderDate,OrderStatus statusOfOrder){

            s_OrderId++;
            OrderId = "OID"+s_OrderId;
            UserId = userId;
            MedicineId = medicineId;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            StatusOfOrder = statusOfOrder;

         }





        
    }
}
