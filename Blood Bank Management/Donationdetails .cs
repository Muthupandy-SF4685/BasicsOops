using System;

namespace Blood_Bank_Management

{

     /// <summary>
     /// 
     /// </summary>
      public enum BloodGroup{Select,A_Positive, B_Positive, O_Positive, AB_Positive}
    public class Donationdetails 
    {
      
      public static int s_DonationId =1000;

        // Donation ID (Auto increment - DID1001)
        // Donor Id
        // Donation Date
        // Weight
        // Blood Pressure
        // Hemoglobin Count (above 13.5)
        // Blood Group – (Enum – A_Positive, B_Positive, O_Positive, AB_Positive)

     //Properties:

     public string DonationId {get; set;}
     
     public string DonorId {get; set;}
     public DateTime DonationDate {get; set;}

     public int Weight {get; set;}

     public double BloodPressure {get; set;}
     
     public double HemoglobinCount {get; set;}

     public BloodGroup BloodGroupType {get; set;}

    
    public Donationdetails(string donorId,DateTime donationDate,int weight,double bloodPressure,double hemoglobinCount,BloodGroup bloodGroupType){
   
       s_DonationId++;
       DonationId = "DID" + s_DonationId;
       DonorId = donorId;
       DonationDate = donationDate;
       Weight = weight;
       BloodPressure = bloodPressure;
       HemoglobinCount = hemoglobinCount;
       BloodGroupType = bloodGroupType;

     
    }


    }
}
