using System;

namespace CovidVaccination
{
     //VaccineName {Enum – Covishield, Covaccine}
     public enum VaccineName{Select,Covishield, Covaccine}
    public class Vaccine
    {
      // a.	VaccineID {Auto-Incremented ID – CID2000}
      private static int s_VaccineId = 2000;
    
     

      //properties
      public string VaccineId {get;}
      public VaccineName VaccineName {get; set;}

      public int NoOfDoseAvailable {get; set;}

       //constructor
      public Vaccine(VaccineName vaccineName,int noOfDoseAvailable){
        s_VaccineId++;
        VaccineId = "CID"+s_VaccineId;
        VaccineName = vaccineName;
        NoOfDoseAvailable = noOfDoseAvailable;
      }

    }
}
