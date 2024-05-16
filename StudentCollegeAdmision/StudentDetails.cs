using System;

namespace CollegeAdmision
{
    //Enum declare
    public enum Gender{select,male,female,TransGender}
    public class StudentDetails
    {
 
    //properties   
    private static int s_studentId =3000; //static field
   
     public string StudentId {get;}  //read only property
    public string Name{ get; set;}

    public string FatherName{get; set;}

    public DateTime DateofBirth{get; set;}

    public Gender GenderType{get; set;}

    public int ChemistryMark{get; set;}

    public int PhysicsMark{get; set;}

    public int MathsMark{get; set;}


    public StudentDetails(string name, string fatherName,DateTime dateofBirth,Gender genderType,int physics,int chemistry,int maths){

        s_studentId++;
        StudentId = "SID"+ s_studentId;
        Name= name;
        FatherName=fatherName;
        DateofBirth=dateofBirth;
        GenderType=genderType;
        ChemistryMark = chemistry;
        PhysicsMark = physics;
        MathsMark = maths;

        

    }
          //showing average
          public double Average(){
            double average= (double)(ChemistryMark + PhysicsMark + MathsMark)/3;
            return average;
          }

          // finding eligible
                   public bool IsEligible(double cutoff){
                    if(Average()>=75.0){
                        return true;
                    }
                        return false;
                   }
    }
}
        


