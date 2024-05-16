using System;

namespace CollegeAdmision
{
    public class DepartmentDetails
    
    {

      private static int s_DepartmentId =1000;  
    // a.DepartmentID – (AutoIncrement - DID101)
    // b.DepartmentName
    // c.NumberOfSeats

    // properties 
    public string DepartmentID {get; } // read only
    public string DepartmentName {get; set;}
    public int NumberOfSeats {get; set;}
 
      //constructor for intialize values
      public DepartmentDetails(string departmentID,string departmentName,int numberOfSeats){
       
        s_DepartmentId+=1;
        DepartmentID ="DID"+s_DepartmentId;
        DepartmentID = departmentID;
        DepartmentName = departmentName;
        NumberOfSeats = numberOfSeats;

      }



    }
}
