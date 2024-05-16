using System;

namespace Blood_Bank_Management
{
    public class UserRegistration 
    {

         public static int s_DonorId =1000;
    //Donor Id (Auto Incremented which is start from UID1001)
    //Donor Name
    //Mobile Number
    //Blood Group
    //Age
    //LastDonationDate

    //Properties
    public string DonorId {get;}
    public string DonorName {get; set;}
    public string MobileNumber {get; set;}
    public BloodGroup BloodGroup {get; set;}
    public int Age {get; set;}
    public DateTime LastDonationDate {get; set;}


    public UserRegistration(string donorName,string mobileNumber,BloodGroup bloodGroup,int age,DateTime lastDonationDate){

        s_DonorId++;
        DonorId="UID"+s_DonorId;
        DonorName = donorName;
        MobileNumber = mobileNumber;
        BloodGroup = bloodGroup;
        Age=age;
        LastDonationDate = lastDonationDate;

    }

        
    }
}
