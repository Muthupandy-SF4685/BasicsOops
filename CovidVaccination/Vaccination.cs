using System;
using System.Security.Cryptography.X509Certificates;

namespace CovidVaccination
{
     public enum DoseNumber{Select=0,One,Two,Three}
    public class Vaccination
    {
        //static field
        private static int s_VaccinationId =3000;
        // a.	VaccinationID (Auto-Increment ID – VID3000)
        // b.	RegistrationNumber (Beneficiary Reg. num)
        // c.	VaccineID
        // d.	DoseNumber – (Enum - 1,2,3)
        // e.	VaccinatedDate (DateTime.Now)

        public string VaccinationId {get;set}

        public string RegistrationNumber {get; set;}
        public string VaccineId {get; set;}
        public DoseNumber DoseNumber {get; set;}

        public DateTime VaccinatedDate {get; set;}

        

        public Vaccination(string registrationNumber,string vaccineId,DoseNumber doseNumber,DateTime vaccinatedDate){

            s_VaccinationId++;
            VaccinationId = "VID"+s_VaccinationId;
            RegistrationNumber = registrationNumber;
            VaccineId = vaccineId;
            DoseNumber = doseNumber;
            VaccinatedDate = vaccinatedDate;

        }


    }
}
