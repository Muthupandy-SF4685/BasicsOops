using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace EmployeePayrollSystem;

class Program {

     // create list to details
    static List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
     
     // access the current user
    static EmployeeDetails currentUser;
    public static void Main(String[] args){
          
          // call the main menu
        MainMenu();
    }
      // method to display main menu
    static void MainMenu(){
          // list the main menu options
        Console.WriteLine("select the menu options below ");
        
        Console.WriteLine("1.Registration");
        
        Console.WriteLine("2.Login");
        
        Console.WriteLine("3.Exit");
          // get user option
        int choice =int.Parse(Console.ReadLine());

         //switch the user to required options
        switch(choice){

            case 1:{
                   // call the registration form method
                     Registration();
                     MainMenu();
                     break;
            }
            case 2: {
                     //  call the Employee login page
                    EmployeeLogin();
                    break;
            }

            case 3 : {    
                        // call exit option
                    ExitMainMenu();                
                    break;              
                   }

        }
      

     }

    static void Registration(){
    //   EmployeeID - (SF1001), Employee name, Role, WorkLocation (enum),
    //    Team name, Date of Joining, Number of Working Days in Month, 
    //    Number of Leave Taken, Gender (enum – Male, Female )
          
         // Registration form 
        Console.Write("Enter your FullName :");
        string employeeName= Console.ReadLine();
      
        Console.Write("Enter EmployeeRole :");
        string employeeRole= Console.ReadLine();

        Console.Write("Enter or select WorkLocation:");
        Console.Write("1.Chennai 2.Coimbatore 3.Tirunelveli 4.Tenkasi 5.Trichy : ");
        // check the location
        bool temp1= Enum.TryParse<WorkLocation>(Console.ReadLine(),true,out WorkLocation workLocation);

        // loop for until get correct value
        while(!temp1){
              Console.Write("please select valid option or enter correct work Location : ");
            temp1= Enum.TryParse<WorkLocation>(Console.ReadLine(),true,out workLocation);
        }
        Console.Write("Team Name :");
        string teamName= Console.ReadLine();

        Console.Write("Enter your Date of Joining (dd/MM/yyyy) :");
        DateTime dateOfJoining = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);           
          
        //check the Gendertype
        Console.Write("Enter gender 1.Male 2.Female : ");
        bool temp2= Enum.TryParse<Gender>(Console.ReadLine(),true, out Gender genderType);
            
            // loop for until getting vaild GenderType
        while(!temp2){
        Console.WriteLine("please select vaild option or enter correct GenderType");
        temp2= Enum.TryParse<Gender>(Console.ReadLine(),true, out genderType);
        }
          
        // create object
        EmployeeDetails employee = new EmployeeDetails(employeeName,employeeRole,workLocation,teamName,dateOfJoining,genderType);
         
        // Add the deatils to the list
        employeeDetails.Add(employee);
         
        Console.WriteLine($"Registration Successful. your Id :{employee.EmployeeId}");
 
    }
  
    // method for login page
    static void EmployeeLogin() {

        // Ask the user to enter the ID
        Console.Write("Enter your EmployeeId :");
 
        string credentialId =Console.ReadLine().ToUpper();
        bool flag =true;
           // iterate the employee details
        foreach(EmployeeDetails employee in employeeDetails){
             // verify the Employee Id
            if(credentialId.Equals(employee.EmployeeId)){
                flag = false;
                currentUser=employee;
                DisplaySubMenu();
            }    
        }
        // if invaild id display prompt
         if(flag){
                Console.WriteLine("Invalid Employee ID please Enter the correct ID");
                 EmployeeLogin();
        } 

    }

    // method for Display the menu options of login page
    static void DisplaySubMenu(){
         // display options
        Console.WriteLine("1.Calculate Salary");  
        Console.WriteLine("2.Display Details");
        Console.WriteLine("3.Exit");

        int option = int.Parse(Console.ReadLine());
       
        // switch the user to the required option
        switch(option) {
            case 1 :{
                // calculate the salary
                currentUser.SalaryCalculation();
                DisplaySubMenu();
                break;
            }
            case 2 : {
                // Display the Employee details
                DisplayDetails();
                DisplaySubMenu();
                break;
            }
            case 3 : {
                 ExitSubMenu();
                break;
            }

            }
        }     
 
      // Method to Display the Employee Details
     static void DisplayDetails(){
             
        // for each loop to iterate the employee details
        foreach(EmployeeDetails employee in employeeDetails){
            // print the details
        Console.WriteLine($"Name : {employee.EmployeeName}\n Role : {employee.EmployeeRole}\n WorkLocation : {employee.WorkLocation}\n TeamName : {employee.TeamName}\n Date of Joining : {employee.DateOfJoining.ToString("dd/MM/yyyy")}\n Number of Working in a month : {employee.NumberOfWorkingDays}\n Number of leave Taken : {employee.NumberOfLeaveTaken}\n Gender : {employee.GenderType} ");
        }

     }
      // exit method for main menu
     static void ExitMainMenu(){
         // ask the user to confirm exit
         Console.WriteLine("Do you want to Exit (yes or no)");
         //get user input
         string choice = Console.ReadLine().ToLower();
         
        //verify the choice to exit or return to main menu
         if(choice=="no"){
             MainMenu();
         }
      }

      // method for Exit sub menu 
      static void ExitSubMenu(){

      // ask the user to confirm exit
      Console.WriteLine("Do you want to Exit (yes or no)");
      //get user input
      string choice = Console.ReadLine().ToLower();
       //verify the choice to exit or return to main menu

       if(choice=="yes"){
           MainMenu();
       }
       else if(choice=="no"){
            DisplaySubMenu();
       }
      }
 }

    