using System;

namespace CovidVaccination
{
     public enum Gender{Select,Male,Female,Others}
    public class Beneficiary
    {
       //static field
       private static int s_registrationNumber =1000;


        //properties
        // a.RegistrationNumber (Auto-Incremented ID -  BID1000)
        // b.Name
        // c.Age
        // d.Gender (Enum [Male, Female, Others])
        // e.MobileNumber
        // f.City

        public string RegistrationNumber {get;}

        public string Name {get; set;}
        public int Age {get; set;}
        public Gender GenderType {get; set;}

        public string MobileNumber {get; set;}

        public string City {get; set;}


        public Beneficiary(string name, int age, Gender genderType, string mobileNumber,string city){
            
            s_registrationNumber++;
            RegistrationNumber = "BID"+s_registrationNumber;
            Name = name;
            Age = age;
            GenderType =genderType;
            MobileNumber = mobileNumber;
            City = city;
        }



        
    }
}
