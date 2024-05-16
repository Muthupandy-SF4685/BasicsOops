using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace Blood_Bank_Management
{
    public class Operations
    {
        public static List<UserRegistration> userRegistrationDetails = new List<UserRegistration>();
        public static List<Donationdetails> donationdetails = new List<Donationdetails>();

         static UserRegistration currentDonor ;

        public static void AddDefaultData(){

            UserRegistration user1 = new UserRegistration("Ravichandran","8484848",BloodGroup.O_Positive,30,new DateTime(2022,08,25));
            UserRegistration user2 = new UserRegistration("Baskaran","4747447",BloodGroup.AB_Positive,30,new DateTime(2022,09,30));

            userRegistrationDetails.Add(user1);
            userRegistrationDetails.Add(user2);

            Donationdetails donation1 = new Donationdetails("UID1001",new DateTime(2022,06,10),73,120,14,BloodGroup.O_Positive);
            Donationdetails donation2 = new Donationdetails("UID1001",new DateTime(2022,10,10),74,120,14,BloodGroup.O_Positive);
            Donationdetails donation3 = new Donationdetails("UID1002",new DateTime(2022,07,11),74,120,13.6,BloodGroup.AB_Positive);

            donationdetails.Add(donation1);
            donationdetails.Add(donation2);
            donationdetails.Add(donation3);

        }

         public static void MainMenu() {

            bool flag=true;
         do{   

        Console.WriteLine("              Blood Bank Management  ");
        Console.WriteLine("select the options below");
        Console.WriteLine("1.Registration");
        Console.WriteLine("2.login");
        Console.WriteLine("3.Fetch Donor Details");
        Console.WriteLine("4.Exit");

        int options = int.Parse(Console.ReadLine());
        switch(options){

            case 1: {
                 //Registration
                 Registration();
                
                break;
            }
            case 2 : {
                //Login
                UserLogin();
                break;
            }
            case 3 : {
                FetchDonordetails();
                //Fetch Donor Details
                break;
            }
            case 4 : {
                flag = false;
                System.Console.WriteLine("Application exit sucessfully");
                // Exit
                break;
            }
            default:{
                Console.WriteLine("Invalid Option please enter the correct option");
                break;
            }
        }
    }while(flag);
 }

  static void Registration(){

        // Donor Name
        // Mobile Number
        // Blood Group
        // Age
        // Last Donation

        
        Console.Write("Enter your Full Name : ");
        string donorName = Console.ReadLine();
        
        Console.Write("Enter your MobileNumber : ");
        string mobileNumber = Console.ReadLine();
       
        Console.Write("Select your BloodGroup : ");
        Console.WriteLine("1. A_Positive 2. B_Positive, 3. O_Positive, 4. AB_Positive");
        bool temp= Enum.TryParse<BloodGroup>(Console.ReadLine(),true, out BloodGroup bloodGroupType);

        while(!temp){
            temp= Enum.TryParse<BloodGroup>(Console.ReadLine(),true, out  bloodGroupType);

        }


        Console.Write("Enter your Age : ");
        bool tempage = int.TryParse(Console.ReadLine(),out int age);
        while(!tempage){
            Console.WriteLine("Invalid Entry please enter the age as number!");
            Console.Write("Enter your Age : ");
            tempage = int.TryParse(Console.ReadLine(),out  age);
        }
        
        Console.Write("Enter your LastDonation Date (dd/MM/yyyy) : ");

        bool tempLastDonationdate = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None, out DateTime LastDonationdate);
        while(!tempLastDonationdate){
            Console.WriteLine("Invalid Date please enter the required format ");
             Console.Write("Enter your LastDonation Date : ");
            tempLastDonationdate = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None, out LastDonationdate);

        }
        
        
        UserRegistration user = new UserRegistration(donorName,mobileNumber,bloodGroupType,age,LastDonationdate );
        userRegistrationDetails.Add(user);

        Console.WriteLine($"your Registration is successful . Your ID is {user.DonorId}");

      }

      static void UserLogin(){

        Console.Write("Enter your DonorId :");
        string donorId = Console.ReadLine().ToUpper();
        bool flag = true;
        foreach(UserRegistration user in userRegistrationDetails){
            if(user.DonorId.Equals(donorId)){
                Console.WriteLine("Login successful.");
                currentDonor=user;
                 flag = false;
                 //submenu
                 SubMenuOptions();
        }
      }
      if(flag){
        Console.WriteLine("Invalid UserId!");
      } 

    }
    static void SubMenuOptions(){

        bool flag = true;

        do{
                //  i.	Donate Blood
                // ii.	Donation History
                // iii.	Next Eligible Date
                // iv.	Exit

              Console.WriteLine("1.Donate Blood");
              Console.WriteLine("2.Donation History");
              Console.WriteLine("3.Next Eligible Date");
              Console.WriteLine("4.Exit");

              int choice = int.Parse(Console.ReadLine());

               switch(choice){

                case 1: {
                    // Donate Blood
                    DonateBlood();
                    break;
                }
                case 2: {
                    // Donation History
                    DonationHistory();    
                    break;
                }
                case 3: {
                    // Next Eligible Date
                     DateTime eligibleDate = NextEligibleDate();
                     Console.WriteLine($"Your Next Eligible date is {eligibleDate.ToString("dd//MM/yyyy")}");  
                    break;
                }
                case 4: {
                      flag=false;
                      Console.WriteLine("Logged out successfuly");
                    
                    break;
                }
                
                 default:{
                    Console.WriteLine("Invalid Option!");
                    break;
                }
              }
        }while(flag); 

         }

         public static void DonateBlood() {
   // Get the weight, blood pressure, hemoglobin count from the user 

        Console.WriteLine("Enter your weight :");
        int weight = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your HBCount :");
        double hbCount = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter your BloodPressure :");
        double bloodPressure = double.Parse(Console.ReadLine());

         //check Weight is above 50, bp is below 130 hemoglobin count is above 13.
            if(weight>50 && bloodPressure<130 && hbCount>13){
                // Check whether the person’s completed 6 months after donating the blood.
                      DateTime eligibleDate =NextEligibleDate();
                    
                      if(eligibleDate<DateTime.Now){
                    Donationdetails donor = new Donationdetails(currentDonor.DonorId,DateTime.Now,weight,bloodPressure,hbCount,currentDonor.BloodGroup);
                    donationdetails.Add(donor);
                     DateTime nextEligibleDate = DateTime.Now.AddMonths(6);
                    Console.WriteLine($"Blood donated successfully, your id {donor.DonationId} ");
                    Console.WriteLine($"your next eligible date of donation is {nextEligibleDate.ToString("dd/MM/yyyy")}");
                      }
                      else{
                      Console.WriteLine("your are not eligible to donate because of not completion of six months of Last Donation");
                      Console.WriteLine($"your next eligible date is {eligibleDate.ToString("dd/MM/yyyy")}");
                      }
                    }
                    else {
                        Console.WriteLine("your are not eligible to donate Blood");
                    }

         }

            
     public static void DonationHistory(){
        bool flag = true;

        foreach(Donationdetails donation in donationdetails){
            if(currentDonor.DonorId.Equals(donation.DonorId)){
                flag=false;
                Console.WriteLine($"DonationID : {donation.DonationId}	DonarID : {donation.DonorId}  DonationDate : {donation.DonationDate.ToString("dd/MM/yyyy")} Weight : {donation.Weight}	BloodPressure : {donation.BloodPressure} HBCount : {donation.HemoglobinCount} Blood Group{donation.BloodGroupType}");
            }

        }
        if(flag){
            Console.WriteLine("No History found");
            Console.WriteLine();
        }

     }



public static DateTime NextEligibleDate(){
    // Show the next eligible date for the user (6 months from the date of last donation). 
       int count =0;
    DateTime date =new DateTime();
    foreach(Donationdetails donation in donationdetails){
        if(currentDonor.DonorId.Equals(donation.DonorId)){
            count++;
        }
    }

    if(count ==0){
        DateTime eligibilityDate = currentDonor.LastDonationDate.AddMonths(6);
        date=eligibilityDate;      

    }
    
    else if(count==1){
         foreach(Donationdetails donation1 in donationdetails){
        if(currentDonor.DonorId.Equals(donation1.DonorId)){
        
        date= donation1.DonationDate.AddMonths(6);  
    }
         }
         
    }
    else if(count>=2){
    
    DateTime[] findLastDonationDate = new DateTime[count];
    int k=0;
    foreach(Donationdetails donation in donationdetails){
        if(currentDonor.DonorId.Equals(donation.DonorId)){
        findLastDonationDate[k]= donation.DonationDate;
        k++;
        }
        
    }
    DateTime maxDate = findLastDonationDate[0];

    for(int i=0; i<findLastDonationDate.Length-1; i++){
        for(int j=1; j<findLastDonationDate.Length; j++){
            if(findLastDonationDate[i]<findLastDonationDate[j]){
                maxDate=findLastDonationDate[j];
            }
            else{
                maxDate = findLastDonationDate[i];
            }
        } 
    }
         
         date = maxDate.AddMonths(6); 
         
        
     }
     return date;

}

public static void FetchDonordetails(){
     
    //  Ask for Blood Group
    Console.Write("Select your BloodGroup : ");
    Console.WriteLine("1. A_Positive 2. B_Positive, 3. O_Positive, 4. AB_Positive");
        bool temp= Enum.TryParse<BloodGroup>(Console.ReadLine(),true, out BloodGroup bloodGroupType);

        while(!temp){
            Console.Write("Invalid option please enter correct option :");
            temp= Enum.TryParse<BloodGroup>(Console.ReadLine(),true, out  bloodGroupType);

        }
        
         List<string> donationList = new List<string>();
         foreach(Donationdetails donation in donationdetails){
            if(donation.BloodGroupType.Equals(bloodGroupType)){
                donationList.Add(donation.DonorId);
            }
         }
                donationList=donationList.Distinct().ToList();   

           foreach(string details in donationList){                  

        foreach(UserRegistration user in userRegistrationDetails){
    
                if(details.Equals(user.DonorId)){
        
                // display the donor’s name and phone number and native place.
                Console.WriteLine($"Name : {user.DonorName} PhoneNumber : {user.MobileNumber}");
                
                }
                }
           }
               
            }
        
        }
        }




