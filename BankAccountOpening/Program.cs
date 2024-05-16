using System;
using System.Collections.Generic;
using System.ComponentModel;
using BankAccountOpening;

namespace BankAccountOpening;

    
class Program {

   // create list to store details
    static List<AccountDetails> accountDetails = new List<AccountDetails>();

    // local variable for acsess curent user.
    static AccountDetails currentUser;
    public static void Main(string[] args){
        
        //greetings
        Console.WriteLine("Hi welcome to HDFC Bank");
        // method call to display options;
        MainMenu();

         
    }

      // method to display the options and select the option
     static void MainMenu(){
         
        
        Console.WriteLine("select the menu options below ");
        
        // 1 for registration 
        Console.WriteLine("1.Registration");
        // 2 for login
        Console.WriteLine("2.Login");
        // 2 for exit
        Console.WriteLine("3.Exit");
          
          //get user input to get choice
        int choice =int.Parse(Console.ReadLine());

           // swtich case for selected options
        switch(choice){
          
              // case 1 get the user to registration page
            case 1:{
                     Registration();
                     MainMenu();
                     break;
            }
            // case 2 get the user to login page
            case 2: {
                     CustomerLogin();
                     break;
            }
              // case 2 get the user to login page      
            case 3 : {    
                     ExitMenu();                
                     break;              
                 }
        }     
     }

            // method for registration form
    static void Registration(){
        // Customer Id -(HDFC1001), Customer name, Balance, Gender (enum),
        //  Phone, Mail Id, Date of Birth

        // get the user details
        Console.Write("Enter your FullName :");
           string name= Console.ReadLine();
      
       Console.Write("Enter gender 1.Male 2.Female : ");
        bool temp= Enum.TryParse<Gender>(Console.ReadLine(),true, out Gender gender);
             // check if user enter wrong options 
        while(!temp){
            Console.WriteLine("please select vaild option or enter correct Gender Detailw213");
            temp= Enum.TryParse<Gender>(Console.ReadLine(),true, out gender);

        }

        Console.Write("Enter your PhoneNumber :");
        String phoneNumber = Console.ReadLine();
        
        Console.Write("Enter your Mail-Id :");
        string mailId = Console.ReadLine();

        Console.Write("Enter your Date of Birth (dd/MM/yyyy) :");
        DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
             
            //create object 
        AccountDetails customer1 = new AccountDetails(name,gender,phoneNumber,mailId,dateOfBirth);
             
             // add the details to the list
        accountDetails.Add(customer1);
         
         Console.WriteLine($"Registration Successful. your Id :{customer1.CustomerId}");

        
        
    }
        
        // method for customer login page
        static void CustomerLogin() {

        Console.Write("Enter your CustomerId :");
          // get the customerId
        string credentialId =Console.ReadLine().ToUpper();
        bool flag =true;

            // iterate the each customer datails
        foreach(AccountDetails customer in accountDetails){
                 // verify the customerId matches
            if(credentialId.Equals(customer.CustomerId)){
                 flag = false;
                 currentUser = customer;
                 //if matches display the options
                 SubMenuOptions();

            }
        }       
           // if customerId not matches show prompt and ask to enter again
         if(flag){
                Console.WriteLine("Invalid User ID please reEnter the correct ID");
                CustomerLogin();

    }
    }      
       // method for submenu Options
         static void SubMenuOptions(){
             // display the options
           Console.WriteLine("1.Deposit");  
           Console.WriteLine("2.Withdraw");
           Console.WriteLine("3.Balance Check");
           Console.WriteLine("4.Exit");
           
           // user option from user
        int option = int.Parse(Console.ReadLine());
             

             // switch the user to the selected option
        switch(option){
            case 1 :{

                // ge the user to the deposit
                DepositAmount();
                SubMenuOptions();
                break;
            }
            case 2 : {
                // get the user to withdrawal
                currentUser.Withdraw();
                SubMenuOptions();
                break;
            }
            case 3 : {
                //to display the current balance
                currentUser.BalanceCheck();
                SubMenuOptions();
                break;
            }

            case 4 : {
                // exit and get to the main menu
                SubExitMenu();
                break;
                 }
            }          

        }             
               
            // method for exit option in main menu
            static void ExitMenu(){
                // ask the user to confirm the exit
            Console.WriteLine("Do you want Exit (yes or no)");
            string check = Console.ReadLine().ToLower();
            //verify the choice to exit or get to the mainmenu
            if(check=="no"){
                MainMenu();
            }
            
        }
        // method for exit option in sub menu
        static void SubExitMenu(){
            // ask the user to confirm the exit in submenu
            Console.WriteLine("Do you want Exit (yes or no)");
            // user input
            string check = Console.ReadLine().ToLower();
            // verify the choice and get to the page or exit
            if(check=="yes"){
                MainMenu();
            }
            else{
                SubMenuOptions();
            }
            
        } 

        static void DepositAmount(){

            Console.WriteLine("Please Enter the cash");
              // get the amount from user
              double depositAmount = double.Parse(Console.ReadLine());

              double balanceAmount = currentUser.deposit(depositAmount);
              Console.WriteLine($"your Amount {depositAmount} was deposited successfuly."); 

              // ask the customer to check the balance after deposit
              Console.WriteLine("Do you want to check balance (yes or no) :");
              string check = Console.ReadLine();

                // if yes display the currentBalance
              if(check=="yes"){
                     Console.WriteLine("Current BalanceAmount :" +balanceAmount);
                      }
        } 

        static void WithdrawAmount(){

            Console.WriteLine("please Enter the Withdrawal amount");
              // ask the withdraw amount
              double withDrawAmount = double.Parse(Console.ReadLine());
                // if balance is not enough display the message
              if(withDrawAmount>s_balanceAmount){
                   Console.WriteLine(" oops Not enough money to withdraw");
              }
              // ask the customer to want check balance or not
             Console.WriteLine("Do you want to check balance (yes or no):");
              string check = Console.ReadLine();

        }   

}