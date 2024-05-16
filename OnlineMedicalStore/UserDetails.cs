using System;

namespace OnlineMedicalStore
{
    public class UserDetails
    {
        

        private static int s_UserId =1000;
        private static double _Balance =0;
        /*Properties:
	     UserID (Auto-increment – UID1000)
	     UserName
        Age
	City
	PhoneNumber
	Balance */

    public string UserId {get;}

    public string UserName {get; set;}
    public int Age {get; set;}
    public string City {get; set;}
    public string PhoneNumber {get; set;}

    public double Balance {get {return _Balance;}}

    public UserDetails (string userName, int age, string city, string phoneNumber){
         
         s_UserId++;
         UserId = "UID" +s_UserId;
         UserName = userName;
         Age = age;
         City = city;
         PhoneNumber = phoneNumber;
        

    }

    public double BalanceDisplay(){
        return Balance;
    }

        
    }
}
