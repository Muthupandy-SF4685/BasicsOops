using System;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {

        //static field for medicineId
        private static int s_MedicineId =2000;
       /* 
a.	MedicineID (Auto-increment – MD2000)
b.	MedicineName
c.	AvailableCount
d.	Price
e.	DateOfExpiry */

      // Properties

      public string MedicineId {get; set;}
      public string MedicineName {get; set;}
      public int AvailableCount {get; set;}
      public double Price {get; set;}
      public DateTime DateOfExpiry {get; set;}


     public MedicineDetails(string medicineName, int availableCount, double price, DateTime dateOfExpiry){

        s_MedicineId++;
        MedicineId = "MID"+s_MedicineId;
        MedicineName = medicineName;
        AvailableCount =availableCount;
        Price = price;
        DateOfExpiry = dateOfExpiry;

     }
        
    }
}
