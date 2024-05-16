using System;

namespace EmployeePayrollSystem
{ 
      // create enum for Gender
     public enum Gender{select,Male,Female}
     // Enum for Work location
     public enum WorkLocation {select,Chennai,Coimbatore,Tirunelveli,Tenkasi,Trichy}
    public class EmployeeDetails
    {

         // create static field for EmployeeID and salary
         private static int s_employeeId = 1000;
         private static double s_Salary = 0;
        // properties – EmployeeID - (SF1001), Employee name, Role,
        //  WorkLocation (enum), Team name, Date of Joining, 
        //  Number of Working Days in Month, Number of Leave Taken, 
        //  Gender (enum – Male, Female )
        //properties
         public double Salary {get; set;}
        public string EmployeeId {get; } // Read Only
        public string EmployeeName {get; set;}
        public string EmployeeRole {get; set;}
        public WorkLocation WorkLocation {get; set;}
        public string TeamName {get; set;}
        public DateTime DateOfJoining {get; set;}
        public int NumberOfWorkingDays {get; set;}
        public int NumberOfLeaveTaken {get; set;}
        public Gender GenderType {get; set;}

          // create constructor
        public EmployeeDetails(string employeeName,string employeeRole, WorkLocation workLocation,string teamName,DateTime dateofJoining,Gender gender)
        { 
             // increament the Employee ID
            s_employeeId+=1;
            EmployeeId = "SF" +s_employeeId;
            EmployeeName=employeeName;
            EmployeeRole= employeeRole;
            WorkLocation = workLocation;
            TeamName = teamName;
            DateOfJoining =dateofJoining;
            GenderType = gender;

        }
        // Method to calculate the salary
       public void SalaryCalculation(){

        // Ask to enter the salary date    
        Console.WriteLine("Enter the Salary Date:");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        //get the number of working days
       int numberOfWorkingDays = DateTime.DaysInMonth(date.Year, date.Month);
       
       // Ask to Enter the number of working days
       Console.WriteLine("Enter the Number of leave taken :");
       NumberOfLeaveTaken = int.Parse(Console.ReadLine());
      
       // calculate the salary
       int salary = (numberOfWorkingDays - NumberOfLeaveTaken) * 500;
       // print the salary detail
       Console.WriteLine("Salary: " + salary);
}

    }
}
