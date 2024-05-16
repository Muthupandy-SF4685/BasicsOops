using System;
using System.Collections.Generic;
namespace EB_BillCalculation;

class Program{
      // create list to store details  
    static List<EbBillDetails> ebBillDetails = new List<EbBillDetails>();
     // access current user details
    static EbBillDetails currentUser;

    public static void Main(string[] args){
        
        // call the Main method and it display the option
        MainMenu();

    }
      // method for main menu
    static void MainMenu(){
        
        // list the options
        Console.WriteLine("select the menu options below ");
        
        Console.WriteLine("1.Registration");
        
        Console.WriteLine("2.Login");
        
        Console.WriteLine("3.Exit");
           // get user choice
        int choice =int.Parse(Console.ReadLine());

        // switch  case for the options based operations
        switch(choice){

            case 1:{
                    // get to the registration form
                     Registration();
                     // return to the main menu
                     MainMenu();
                     break;
            }
            case 2: { 
                    // get to the login page
                    LoginPage();
                    break;
            }

            case 3 : {    
                        // exit from the application
                        ExitApplication();           
                        break;              
                   }

        }
}

           // method for registration
           static void Registration(){
            // Meter ID -(EB1001), Username, Phone number, Mail id, Units Used =0

            Console.Write("Enter your Name : ");
            string userName= Console.ReadLine();

            Console.Write("Enter your 10 digit PhoneNumber : ");
            string phoneNumber =Console.ReadLine();

            Console.Write("Enter your Mail-id : " );
            string mailId =Console.ReadLine();

            

              // create object
            EbBillDetails customer = new EbBillDetails(userName,phoneNumber,mailId);
            // Add details to the list
              ebBillDetails.Add(customer);
             // display message after successful registration
              Console.WriteLine($"Registration is successful. your MeterID :{customer.MeterId}");
              Console.WriteLine();
            
           }
           //  method login page
           static void LoginPage(){
            // ask the user to enter credential
              Console.Write("Enter your MeterId : ");
              string meterid = Console.ReadLine().ToUpper();
              bool flag =true;
                // foreach for iterate details of customer
              foreach(EbBillDetails customer in ebBillDetails){
                // verify the meterId and credential matches
                if(meterid.Equals(customer.MeterId)){
                   flag = false;
                   currentUser = customer;
                   // if matches display the sub menu options
                   SubMenuOptions();

                }

              }
                // if match not found ask to reenter
              if(flag){
                Console.WriteLine("Invalid MeterID please Enter the valid ID ");
                 LoginPage();
              }
           }
            // method for submenu options
           static void SubMenuOptions(){
            // display the options line ny line
            Console.WriteLine("select the options below -");
            Console.WriteLine("1.Calculate Amount");
            Console.WriteLine("2.Display Details");
            Console.WriteLine("3.Exit");
             // ask the user for option
            int choice = int.Parse(Console.ReadLine());
            // swtich statement for get to the options
            switch(choice){
                case 1 : {
                       // calculate bill amount
                      currentUser.CalculateAmount();
                      SubMenuOptions();
                      break;
                }

                case 2 :{
                        // display user details
                       DisplayUserDetails();
                       SubMenuOptions();
                    break;
                }

                case 3 :{
                     // exit and return to main menu
                     ExitSubMenu();
                    break;
                }
            }
     }

            // Display user detils
            static void DisplayUserDetails(){
             // foreach loop to iterate the details
            foreach(EbBillDetails customer in ebBillDetails){
                Console.WriteLine($"MeterId :{customer.MeterId} Name : {customer.UserName}\n PhoneNumber : {customer.PhoneNumber}\n Mail-Id : {customer.MailId} ");
            }
        }
            
            // Exit method for Main menu
        static  void ExitApplication(){
            // ask the user to confirmation of exit
            Console.WriteLine("Do you want to Exit (yes or no)!");
            string check = Console.ReadLine();
            // if yes exit or no stay in main menu
            if(check=="no"){
                MainMenu();
            }
        }

        // Exit otpion for submenu
         static void ExitSubMenu(){
            // ask the user to confirmation of exit
            Console.WriteLine("Do you want to Exit (yes or no)!");
            string check = Console.ReadLine();
            // if yes return main menu
            if(check=="yes"){
                MainMenu();
            }
            // else no stay in logged page
            else if(check=="no"){
                SubMenuOptions();
            }
        }

}