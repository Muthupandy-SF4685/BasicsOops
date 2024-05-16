using System;

using System.Security.Cryptography.X509Certificates;

namespace OnlineCourseEnrollment;

class Program {

   // create list to store details
    public static CustomList<UserDetails> userDetails= new CustomList<UserDetails>();
   public static CustomList<CourseDetails> courseDetails= new CustomList<CourseDetails>();
    public static CustomList<EnrollmentDetails> enrollmentDetails= new CustomList<EnrollmentDetails>();

    // local variable for acsess curent user.
    static UserDetails currentUser;
     
     static CourseDetails courseUser;
    static EnrollmentDetails enrollUser;
    public static void Main(string[] args){
        
        //greetings
        Console.WriteLine("Syncfusion online course Enrollment");
        // method call to display options;
        DefaultData();
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
        /*a.Username
          b.Age
          c.Gender
          d.Qualification
          e.Mobile Number
          f.Mail ID*/


        // get the user details
        Console.Write("Enter your FullName :");
           string name= Console.ReadLine();

        Console.Write("Enter your Age :"); 
        int age = int.Parse(Console.ReadLine());
      
        Console.Write("Enter gender 1.Male 2.Female : ");
        bool temp= Enum.TryParse<Gender>(Console.ReadLine(),true, out Gender gender);
             // check if user enter wrong options 
        while(!temp){
            Console.WriteLine("please select vaild option or enter correct Gender Detailw213");
            temp= Enum.TryParse<Gender>(Console.ReadLine(),true, out gender);
        }
      
        Console.Write("Enter your Qualification :");
        string qualification = Console.ReadLine();

        Console.Write("Enter your PhoneNumber :");
        String phoneNumber = Console.ReadLine();
        
        Console.Write("Enter your Mail-Id :");
        string mailId = Console.ReadLine();
   
        //create object 
        UserDetails user = new UserDetails(name,age,gender,qualification,phoneNumber,mailId);
             
        // add the details to the list
        userDetails.Add(user);
         
         Console.WriteLine($"Registration Successful. your Id :{user.RegistrationId}");   
        
    }
        
        // method for customer login page
        static void CustomerLogin() {

        Console.Write("Enter your UserId :");
          // get the customerId
        string userid =Console.ReadLine().ToUpper();
        bool flag =true;

            // iterate the each customer datails
        foreach(UserDetails user in userDetails){
                 // verify the customerId matches
            if(userid.Equals(user.RegistrationId)){
                 flag = false;
                 currentUser = user;
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

             /*a.Enroll Course
              b.View Enrollment History
              c.Next Enrollment 
              d.Exit*/

             // display the options
           Console.WriteLine("1.Enroll Course");  
           Console.WriteLine("2.View Enrollment History");
           Console.WriteLine("3.Next Enrollment");
           Console.WriteLine("4.Exit");
           
           // user option from user
        int option = int.Parse(Console.ReadLine());
             

             // switch the user to the selected option
        switch(option){
            case 1 :{

                // ge the user to the 
                EnrollCourse();
                SubMenuOptions();
                break;
            }
            case 2 : {
                // get the user to 
                EnrollmentHistory();
                SubMenuOptions();
                break;
            }
            case 3 : {
                //to display the 
                NextEnrollment();
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

               static void EnrollCourse(){

                foreach(CourseDetails course in courseDetails){
                Console.Write($" CourseID : {course.CourseId}\t CourseName : {course.CourseName}\t TrainerName : {course.TrainerName}\t CourseDuration : {course.CourseDuration}\t SeatsAvailable : {course.SeatsAvailable}\n");
                }
                Console.WriteLine("Enter Course ID to enroll");
                string courseid = Console.ReadLine();
                  int count =0;
                  bool flag = true;
                foreach(CourseDetails course1 in courseDetails){
                    if(courseid.Equals(course1.CourseId)){
                        flag=false;
                        if(course1.SeatsAvailable>0){
                            foreach(EnrollmentDetails enrollment1 in enrollmentDetails){
                                if(currentUser.RegistrationId.Equals(enrollment1.RegistrationId)){
                                    count++;
                                }
                            }

                            if(count<2){
                                EnrollmentDetails enrollment = new EnrollmentDetails(courseid,currentUser.RegistrationId,DateTime.Now);
                                course1.SeatsAvailable--;
                                enrollmentDetails.Add(enrollment);
                            }
                            else if (count==2){

                                //next availability
                                NextAvailability();
                            }

                        }
                        else {
                            System.Console.WriteLine("Seats are not available for the current course");
                            break;
                        }
                    }
                    else {
                        Console.WriteLine("Invalid course id");
                        break;
                    }
                }
  
                
               }
        public static void NextAvailability(){
                  
        DateTime[] dates = new DateTime[2];
                  
        int i =0;

        foreach(EnrollmentDetails enrollment in enrollmentDetails){
        foreach(CourseDetails course in courseDetails){
         if(currentUser.RegistrationId.Equals(enrollment.RegistrationId) && enrollment.CourseId.Equals(course.CourseId)){
                      
                       
        dates[i]=enrollment.EnrollmentDate.AddDays(course.CourseDuration);
                       
                       i++;
                      
                    }
                }

                }

                if(dates[0]>dates[1]){
                    Console.WriteLine($"You have already enrolled two courses. You can enroll next course on {dates[1].ToString("dd/MM/yyyy")}.");
                }
                else {
                     Console.WriteLine($"You have already enrolled two courses. You can enroll next course on {dates[0].ToString("dd/MM/yyyy")}.");
                }
           }

    static void EnrollmentHistory(){
        bool flag= true;
    foreach(EnrollmentDetails enrollment in enrollmentDetails){
        if(currentUser.RegistrationId.Equals(enrollment.RegistrationId)){
            flag=false;
     Console.WriteLine($"EnrollmentID :{enrollment.EnrollmentId}	CourseID : {enrollment.CourseId}	RegistrationID : {enrollment.RegistrationId}	EnrollmentDate : {enrollment.EnrollmentDate}");
       
         }
      }

      if(flag){
        System.Console.WriteLine("No history found");
      }
    }

    static void NextEnrollment(){

        int count =0;
        foreach(EnrollmentDetails enrollment in enrollmentDetails){
            if(currentUser.RegistrationId.Equals(enrollment.RegistrationId)){
                count++;
            }
        }

        if(count<2){
            Console.WriteLine("you can enroll on today itself ");

        }
        else if(count==2){
            NextAvailability();
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

        static void DefaultData() {

        UserDetails user1 = new UserDetails("Ravichandran",30,Gender.male,"ME","9938388333","ravi@gmail.com");
        UserDetails user2 = new UserDetails("Priyadharshini",25,Gender.female,"BE","9944444455","priya@gmail.com");
        userDetails.Add(user1);
        userDetails.Add(user2);
       

        CourseDetails course1 = new CourseDetails("C#","Baskaran",5,0);
        CourseDetails course2 = new CourseDetails("HTML","Ravi",2,5);
        CourseDetails course3 = new CourseDetails("CSS","Priyadharshini",2,3);
        CourseDetails course4 = new CourseDetails("JS","Baskaran",3,1);
        CourseDetails course5 = new CourseDetails("TS","Ravi",1,2);

       courseDetails.AddRange(new CustomList<CourseDetails>{course1,course2,course3,course4,course5}); 


        EnrollmentDetails enroll1 = new EnrollmentDetails("CS2001","SYNC1001",  new DateTime(2024,01,28));
        EnrollmentDetails enroll2 = new EnrollmentDetails("CS2003","SYNC1001", new DateTime(2024,02,15));
        EnrollmentDetails enroll3 = new EnrollmentDetails("CS2004","SYNC1002",new DateTime(2024,02,18));
        EnrollmentDetails enroll4 = new EnrollmentDetails("CS2002","SYNC1002",new DateTime(2024,02,20));


        enrollmentDetails.Add(enroll1);
        enrollmentDetails.Add(enroll2);
        enrollmentDetails.Add(enroll3);
        enrollmentDetails.Add(enroll4);



        }
                

}
        

        



