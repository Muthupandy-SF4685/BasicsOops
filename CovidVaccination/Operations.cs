using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace CovidVaccination
{
    public class Operations
    {
        public static List<Beneficiary> beneficiariesList = new List<Beneficiary>();
        public static List<Vaccine> vaccineList = new List<Vaccine>();
        public static List<Vaccination> vaccinationList =new List<Vaccination>();

        static Beneficiary currentUser;
        static Vaccine currentVaccine;
        static Vaccination currentVaccination;
        
        public static void DefaultData(){
          
          //Beneficiary Defaultdata
          
          Beneficiary user1 = new Beneficiary("Ravichandran",21,Gender.Male,"8484484123","Chennai");

          Beneficiary user2 = new Beneficiary("Baskaran",22,Gender.Male,"8484747321","Chennai");

          beneficiariesList.Add(user1);
          beneficiariesList.Add(user2);

          //Vaccine Defaultdata
          Vaccine vaccine1 = new Vaccine(VaccineName.Covishield,50);
          Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine,50);
        
           vaccineList.Add(vaccine1);
           vaccineList.Add(vaccine2);

          //Vaccine Defaultdata
          Vaccination vaccinate1 = new Vaccination("BID1001","CID2001",DoseNumber.One,new DateTime(2024,03,31));
          Vaccination vaccinate2 = new Vaccination("BID1001","CID2001",DoseNumber.Two,new DateTime(2024,04,30));
          Vaccination vaccinate3 = new Vaccination("BID1002","CID2002",DoseNumber.One,new DateTime(2024,03,04));

          vaccinationList.Add(vaccinate1);
          vaccinationList.Add(vaccinate2);
          vaccinationList.Add(vaccinate3);
          
        }

        public static void MainMenu(){

                // 1.BeneficiaryRegistration
                // 2.Login 
                // 3.GetVaccineInformation
                // 4.Exit

            Console.WriteLine("Select the option Below ");
            Console.WriteLine("1. BeneficiaryRegistration");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. GetVaccineInformation");
            Console.WriteLine("4. Exit");
           
           int option = int.Parse(Console.ReadLine());
           bool flag = true;

           do{
            switch(option){

                case 1 : {
                    //BeneficiaryRegistration
                    BeneficiaryRegistration();
                    break;
                }
                case 2 : {
                    //login
                    UserLogin();
                    break;
                }
                case 3 : {
                    //GetVaccineInformation
                    GetVaccineInformation();
                    break;
                }
                case 4 : {
                    //Exit
                    flag = false;
                    Console.WriteLine("Logged out successfully");
                    break;
                }
                default : {
                    Console.WriteLine("Invalid Option");
                    break;
                }


            }
           }while(flag);
            
          }
          
           // method for registration
          public static void BeneficiaryRegistration(){

            // Need to get the below details from the user for the beneficiary registration

            Console.Write("Enter your Full Name :");
            string name = Console.ReadLine();
            
            Console.Write("Enter your Age : ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("select your Gender (1.Male 2.Female 3.Others):");
            bool tempGender = Enum.TryParse<Gender>(Console.ReadLine(), out Gender genderType);

            while(!tempGender){
                 Console.WriteLine("Invalid option please select valid option");
                tempGender = Enum.TryParse<Gender>(Console.ReadLine(), out genderType);

            }

            Console.Write("Enter your MobileNumber :");
            string mobileNumber = Console.ReadLine();
            
            Console.Write("Enter your City : ");
            string city= Console.ReadLine();

            Beneficiary user = new Beneficiary(name,age,genderType,mobileNumber,city);
            beneficiariesList.Add(user);
            
            Console.WriteLine($"your registration is successfull. your registered is {user.RegistrationNumber}");

          }

          // method for user login
          public static void UserLogin(){

            Console.WriteLine("Please enter your Benificiary Id");

            string beneficiaryId = Console.ReadLine().ToUpper();
               bool flag = true;
            foreach(Beneficiary beneficiary in beneficiariesList){
                if(beneficiaryId.Equals(beneficiary.RegistrationNumber)){
                    Console.WriteLine("Login successful");
                     flag=false;
                     currentUser = beneficiary;
                       SubMenu();
                }
            }
            if(flag){
                Console.WriteLine("Invalid Register Number!");
                UserLogin();
            }

            

          }

        // method for submenu
      public static void SubMenu(){
        Console.WriteLine("select the options below");

        // 1.	ShowMyDetails
        // 2.	TakeVaccination
        // 3.	MyVaccinationHistory
        // 4.	NextDueDate
        // 5.	Exit

        Console.WriteLine("1.ShowMyDetails");
        Console.WriteLine("2.TakeVaccination");
        Console.WriteLine("3.MyVaccinationHistory");
        Console.WriteLine("4.NextDueDate");
        Console.WriteLine("5.Exit");

        int choice = int.Parse(Console.ReadLine());
        bool flag = true;
        
        do{
        switch(choice){
            case 1: {
                //  ShowMyDetails
                 ShowMyDetails();
                break;
            }
            case 2: {
                // TakeVaccination
                TakeVaccination();
                break;
            }
            case 3: {
                // MyVaccinationHistory
                 MyVaccinationHistory();
                break;
            }
            case 4: {
                // NextDueDate
                 NextDueDate();
                break;
            }
            case 5: {
                flag= false;
                Console.WriteLine("Exit sucessfully");
                MainMenu();
                break;
            }
        }
            
        }while(flag);
        

      }

      public static void ShowMyDetails(){
        // Show the current beneficiary’s personal details in the console

        foreach(Beneficiary beneficiary in beneficiariesList){
            if(currentUser.RegistrationNumber.Equals(beneficiary.RegistrationNumber)){
            Console.WriteLine($"RegisterNumber : {beneficiary.RegistrationNumber}	Name : {beneficiary.Name}	Age :{beneficiary.Age}	Gender : {beneficiary.GenderType}	MobileNumber : {beneficiary.MobileNumber}	City : {beneficiary.City}");
           
            
            }
            
        }

      }

      public static void TakeVaccination(){
            // Show the list of vaccines available and select a vaccine.
            foreach(Vaccine vaccine in vaccineList){
            System.Console.WriteLine($"VaccineID :{vaccine.VaccineId}	VaccineName : {vaccine.VaccineName}	NoOfDoseAvailable : {vaccine.NoOfDoseAvailable}");
            Console.WriteLine();
            }
            // Ask the user to select a vaccine by using a VaccineID and find out if the ID is valid. 

            Console.WriteLine("Select the vaccine Id listed above :");

            string vaccineId = Console.ReadLine().ToUpper();
            
            bool flag = true;
            foreach(Vaccine vaccine1 in vaccineList){
                if(vaccine1.VaccineId.Equals(vaccineId)){
                    flag = false;
                  currentVaccine=vaccine1;
                }

                }
                if(flag){
                Console.WriteLine("Invalid Vaccine id!");
                TakeVaccination();
                }
                
                    int count =0;
                   foreach(Vaccination vaccinate in vaccinationList){
                    if(currentUser.RegistrationNumber.Equals(vaccinate.RegistrationNumber)){
                        currentVaccination=vaccinate;
                        count++;
                    }
                   }
                        // If he didn’t take any vaccines, check that his age is above 14. 
                        if(count==0){
                        //If yes, then allow him to take that vaccine.
                        if(currentUser.Age>14){                   

             Vaccination vaccination = new Vaccination(currentUser.RegistrationNumber,currentVaccination.VaccineId,DoseNumber.One,DateTime.Now);
            //Update the details in his vaccination history list.
                vaccinationList.Add(vaccination);
               //Deduct the count of vaccines available. 
               currentVaccine.NoOfDoseAvailable--;

                        }
                        else{
                            Console.WriteLine("your are not eligible to vaccinate");
                        }
                    }
        // If he took three vaccines, then display “All the three vaccinations are completed; you cannot be vaccinated now.
                    else if(count==3){
                        Console.WriteLine("All the three vaccinations are completed, you cannot be vaccinated now.");
                    }  
        //  If he took one or two vaccines in his vaccination history,  

               else if(count==1 || count==2){
                // find that he has selected the same vaccine type now.
                 if(vaccineId.Equals(currentVaccine.VaccineId)){
            //  If it is yes, then check the date of his last vaccination
                DateTime lastVaccinationDate = LastVaccineDate().AddDays(30);
                  if(DateTime.Now<lastVaccinationDate){
                    if(count==1){
                    Vaccination vaccination =new Vaccination(currentUser.RegistrationNumber,currentVaccine.VaccineId,DoseNumber.Two,DateTime.Now);
                    vaccinationList.Add(vaccination);
                    currentVaccine.NoOfDoseAvailable--;
                    }
                    else{
                        Vaccination vaccination =new Vaccination(currentUser.RegistrationNumber,currentVaccine.VaccineId,DoseNumber.Three,DateTime.Now);
                       vaccinationList.Add(vaccination);
                        currentVaccine.NoOfDoseAvailable--;

                    }
                  }
                    
                 
                 }
                 else{
                    Console.WriteLine($"You have selected a different vaccine”. You can vaccine with {currentVaccine.VaccineName} ");
                 }

               }     
            }


      public static void MyVaccinationHistory(){
        // Show the vaccination details of the current beneficiary if he has completed first/ second/ third vaccinations.
          int count =0;
        foreach(Vaccination vaccinate in vaccinationList){
            if(currentUser.RegistrationNumber.Equals(vaccinate.RegistrationNumber)){
                count++;
            }   
        }
        if(count==3){
                foreach(Vaccination vaccinate1 in vaccinationList){
                    if(currentUser.RegistrationNumber.Equals(vaccinate1.RegistrationNumber)){
                        Console.WriteLine($"VaccinationID : {vaccinate1.VaccinationId}	RegisterNumber : {vaccinate1.RegistrationNumber}	VaccineID : {vaccinate1.VaccineId}	DoseNumber : {vaccinate1.DoseNumber}	VaccinatedDate : {vaccinate1.VaccinatedDate.ToString("dd/MM/yyyy")}");
        
                    }       
                }
            }
      }
      public static void NextDueDate(){
         int count =0;
        foreach(Vaccination vaccinate in vaccinationList){
            if(currentUser.RegistrationNumber.Equals(vaccinate.RegistrationNumber)){
              count++;
            }
        }
        // Show the next due date for the current beneficiary by finding his details from his vaccination history. 
        // If he didn’t take any doses already, then show, “You can take the vaccine now.”. 
        if(count==0){
            Console.WriteLine("You can take the vaccine now.");
        }
        // If either the first or second dose of the vaccine completed, add 30 days to find the next due date for the vaccine.
        if(count==1 || count==2){
        foreach(Vaccination vaccinate in vaccinationList){
            if(currentUser.RegistrationNumber.Equals(vaccinate.RegistrationNumber)){
                DateTime nextDueDate = vaccinate.VaccinatedDate.AddDays(30);
                Console.WriteLine($"your next vaccination date is {nextDueDate.ToString("dd/MM/yyyy")}");
            }
        }
        }
        // If he completed the third dose, display “You have completed all vaccination. Thanks for your participation in the vaccination drive.”
        if(count==3){
            Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
        }

      }
     
     public static void GetVaccineInformation(){
        // Show the available vaccine name and count details in the current date to plan your vaccination today.
         foreach(Vaccine vaccine in vaccineList){

            Console.WriteLine($"VaccineID: {vaccine.VaccineId}	VaccineName : {vaccine.VaccineName}	NoOfDoseAvailable : {vaccine.NoOfDoseAvailable}");
            Console.WriteLine();

         }

     }

     public static DateTime LastVaccineDate(){
        DateTime date = new DateTime();
         List<DateTime>  vaccinationDates = new List<DateTime>();
         int i=0;

        foreach(Vaccination vaccination in vaccinationList){
            vaccinationDates[i]=vaccination.VaccinatedDate;
        }
        foreach(Vaccination vaccination1 in vaccinationList){
        foreach(DateTime vaccinedate  in vaccinationDates){
            if(vaccination1.VaccinatedDate < vaccinedate){
                date=vaccinedate;
            }
        }
        }
        return date;
     }


    }
}
