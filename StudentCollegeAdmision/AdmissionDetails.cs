using System;

namespace CollegeAdmision
{
    public enum AdmissionStatus {select,Admitted,Cancelled}
    public class AdmissionDetails

    {
           private static int s_AdmissionId =1000;
        // a.AdmissionID – (Auto Increment ID - AID1001)
        // b.StudentID
        // c.DepartmentID
        // d.AdmissionDate
        // e.AdmissionStatus – Enum- (Select, Admitted, Cancelled)

        //properties
        public string AdmissionID {get; set;}
        public string StudentID  {get; set;}
        public string DepartmentID {get; set;}
        public DateTime AdmissionDate {get; set;}
        public AdmissionStatus Status {get; set;}

        public AdmissionDetails(string studentId, string departmentID,DateTime admissionDate, AdmissionStatus status)
        {
            s_AdmissionId+=1;
            AdmissionID = "AID"+s_AdmissionId;
            StudentID = studentId;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            Status = status;
        }
        
    }
}
