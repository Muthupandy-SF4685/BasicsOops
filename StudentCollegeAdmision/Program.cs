using System;
using System.Collections.Generic;
using CollegeAdmision;
using static CollegeAdmision.StudentDetails;

namespace CollegeAdmission;

class Program {

    static List<StudentDetails> studentDetails = new List<StudentDetails>();
    static List<DepartmentDetails> departmentDetails = new List<DepartmentDetails>();
    static List<AdmissionDetails> admissionDetails = new List<AdmissionDetails>();
     static StudentDetails currentUser;
     static DepartmentDetails departmentUser;
     static AdmissionDetails admisionUser;
    public static void Main(string[] args){

           DefaultData();
          
           Console.WriteLine("Syncfusion College of Engineering and Technology");

           MainMenu();
    }
      
      // 1.Student Registration
      // 2.Student Login
      // 3.Department wise seat availability
      // 4.Exit
      // method for main menu
      static void MainMenu(){

        Console.WriteLine("1.Registration");
        Console.WriteLine("2.Student Login");
        Console.WriteLine("3.Department Wise Seat Availabilty");
        Console.WriteLine("4.Exit");
        
        int option = int.Parse(Console.ReadLine());

        switch(option){
            case 1 :{
                    Registration();
                    MainMenu();

                break;
            }
            case 2 :{
                    StudentLogin();
                break;
            }
            case 3 :{
                    DepartmentWiseAvailability();
                    MainMenu();

                break;
            }
            case 4 :{
                ExitMenu();
                break;
            }
        }

      }

      static void Registration(){
            
        // a.StudentName
        // b.FatherName
        // c.DOB
        // d.Gender – Enum (Select, Male, Female, Transgender)
        // e.Physics
        // f.Chemistry
        // g.Maths

        Console.WriteLine("Enter your Full Name : ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your Father Name : ");
        string fatherName = Console.ReadLine();

        Console.WriteLine("Enter your Date Of Birth :");
        DateTime dateofBirth =DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        Console.WriteLine("Select Gender : ");
        bool temp= Enum.TryParse<Gender>(Console.ReadLine(),true,out Gender gender);

        while(!temp){
            Console.WriteLine("Invalid option please Enter valid option");
            temp= Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        }

        Console.WriteLine("Enter Physics Mark : ");
        int physicsMark = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Chemistry Mark : ");
        int chemistryMark = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Maths Mark : ");
        int mathsMark = int.Parse(Console.ReadLine());

        StudentDetails student = new StudentDetails(name,fatherName,dateofBirth,gender,physicsMark,chemistryMark,mathsMark);
        studentDetails.Add(student);
       
       Console.WriteLine($"“Student Registered Successfully and StudentID is {student.StudentId} ");
      }

      public static void StudentLogin(){

        Console.Write("Enter your Student ID:");

        string credentialiD =Console.ReadLine();
        bool flag=true;

        foreach(StudentDetails student in studentDetails){
            if(credentialiD.Equals(student.StudentId)){
                //printing the details
                  flag=false;
                  currentUser = student;
                SubMenuOptions();
            }

        }
         while(flag){
            Console.WriteLine("Invalid Id or Id not found");
            credentialiD =Console.ReadLine();
            foreach(StudentDetails student in studentDetails){
            if(credentialiD.Equals(student.StudentId)){
                //printing the details
                  flag=false;
                  currentUser = student;
                SubMenuOptions();
            }

        }

       }

    }

         //a.Check Eligibility
         // b.Show Details
         // c.Take Admission
         // d.Cancel Admission
         // e.Show Admission Details
        // f.Exit

        static void SubMenuOptions(){

            Console.WriteLine("select the options below");

            Console.WriteLine("1.check Eligibility");
            Console.WriteLine("2.Show Details");
            Console.WriteLine("3.Take Admission");
            Console.WriteLine("4.Cancel Admission");
            Console.WriteLine("5.e.Show Admission Details");
            Console.WriteLine("6.Exit");

            int choice = int.Parse(Console.ReadLine());

            switch(choice){
                case 1 : {
                    CheckEligibility();
                    SubMenuOptions();
                    break;
                }
                case 2 : {
                     ShowDetails();
                     SubMenuOptions();

                    break;
                }
                case 3 : {
                     TakeAdmission();
                     SubMenuOptions();
                    break;
                }
                case 4 : {
                    CancelAdmission();
                    SubMenuOptions();
                    break;
                }
                case 5 : {
                    ShowAdmissionDetails();
                    SubMenuOptions();
                    break;
                }
                case 6 : {
                    SubExitMenu();
                    break;
                }
            }
        }


    public static bool CheckEligibility(){
        //get the cutoff value from user
        Console.Write("Enter the cutoff value :");
        int cutoff = int.Parse(Console.ReadLine());
        // check whether it statisfies the condition

        if(currentUser.IsEligible(cutoff))
        {
            Console.WriteLine("you are eligble");
            return true;
        }
        else {
            Console.WriteLine("you are not eligible");
            return false;
        }

    }
    
       // method to show student details
       static void ShowDetails(){

        foreach(StudentDetails student in studentDetails )
        {
            Console.WriteLine($"Name :{student.Name}\n FatherName:{student.FatherName}\n DateOfBirth:{student.DateofBirth.ToString("dd/MM/yyyy")}\n Gender : {student.GenderType}\n chemistry : {student.ChemistryMark}\n physics :{student.PhysicsMark}\n maths :{student.MathsMark}");
        }
    
       }
       static void TakeAdmission(){
        // show the department wise seat availability
        DepartmentWiseAvailability ();

        // ask the student to pick departmentID 
        Console.WriteLine("select the desired DepartmentId");

        string departmentId = Console.ReadLine();
        bool flag = true;
          foreach(DepartmentDetails department in departmentDetails){
            if(departmentId.Equals(department.DepartmentID)){
                flag =false;
                if(CheckEligibility()){
                if(department.NumberOfSeats>0){
                   foreach(AdmissionDetails admission in admissionDetails){
                         if(currentUser.StudentId.Equals(admission.StudentID)){
                            Console.WriteLine("You have already take admission");
                         }
                         else {
                            foreach(DepartmentDetails department1 in departmentDetails){
                              
                              department.NumberOfSeats--;
                            }
                            AdmissionDetails admission1 = new AdmissionDetails(currentUser.StudentId,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                            admissionDetails.Add(admission1);

                            System.Console.WriteLine($"Admission took successfully. Your admission ID is {admission1.AdmissionID}");
                         }
                   }
                }
                else {
                    System.Console.WriteLine("sorry you are not Eligible");
                }
                
            }
            else {
                Console.WriteLine("Department Not Found");
            }
          }
          while(flag){
            Console.WriteLine("Ivalid DepartmentId please Enter correct DepartmentId");
              departmentId = Console.ReadLine();
          }
         
       }

 }

       static void CancelAdmission(){




       }

       static void ShowAdmissionDetails(){

        foreach(AdmissionDetails admission in admissionDetails){

            Console.WriteLine($"AdmissionID : {admission.AdmissionID} StudentID : {admission.StudentID} DepartmentID : {admission.DepartmentID} AdmissionDate : {admission.AdmissionDate} AdmissionStatus : {admission.Status}");
        }


       }
      public static void DefaultData(){
        StudentDetails student1 = new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,1),Gender.male,95,95,95);
        
        StudentDetails student2 = new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.male,95,95,95);

        studentDetails.Add(student1);
        studentDetails.Add(student2);

        DepartmentDetails department1 = new DepartmentDetails("DID101","EEE",29);
        DepartmentDetails department2 = new DepartmentDetails("DID102","CSE",29);
        DepartmentDetails department3 = new DepartmentDetails("DID103","MECH",30);
        DepartmentDetails department4 = new DepartmentDetails("DID104","ECE",30);

        departmentDetails.AddRange(new List<DepartmentDetails> {department1,department2,department3,department4});

        AdmissionDetails admission1 = new AdmissionDetails("SF3001","DID101",new DateTime(2022,05,11),AdmissionStatus.Admitted);
        AdmissionDetails admission2 = new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,12),AdmissionStatus.Admitted);
        
        admissionDetails.Add(admission1);
        admissionDetails.Add(admission2);


      }
      static void DepartmentWiseAvailability (){

        foreach(DepartmentDetails department in departmentDetails){
            Console.WriteLine($"DepartmentID : {department.DepartmentID}\t DepartmentName : {department.DepartmentName}\t NumberofSeats :{department.NumberOfSeats}\n");
        }

      }

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
        static void SubExitMenu() {
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


       
 }


