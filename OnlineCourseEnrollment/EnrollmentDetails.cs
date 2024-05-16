using System;

namespace OnlineCourseEnrollment
{
    /// <summary>
    /// class <see cref="EnrollmentDetails"/> used to collect enrolled details for future reference
    /// </summary>
    public class EnrollmentDetails
    {
       /// <summary>
       /// static field used to auto increament and it uniquely  identify an instance of
       /// </summary>
        private static int s_EnrollmentId = 3000; // static field

           //properties
           /// <summary>
           ///  property EnrollmentId used to get enrollment Id's of the user
           /// </summary>
           /// <value>It allows string value</value>
           public string EnrollmentId {get; set;}
           /// <summary>
           ///  property CourseId used to get course Id's of the user
           /// </summary>
           /// <value>It allows string value</value>
           public string CourseId {get; set;}
           /// <summary>
           ///  property RegistrationId used to get course Id's of the user
           /// </summary>
           /// <value>It allows string value</value>
           public string RegistrationId {get; set;}
           /// <summary>
           /// property EnrollmentDate used to get enrolled date of the user
           /// </summary>
           /// <value>It allows DateTime value</value>
           public DateTime EnrollmentDate {get; set;}

           /// <summary>
           /// Constructor of <see cref="EnrollmentDetails"/> class used to intialize values to its properties
           /// </summary>
           /// <param name="courseId">parameter courseId used to initialize user's courseId to the property</param>
           /// <param name="registrationId">parameter registrationId used to initialize user's registration Id to property</param>
           /// <param name="enrollmentDate">parameter enrollmentDate used to initialize user's enrollment Date to property</param>
           public EnrollmentDetails(string courseId,string registrationId,DateTime enrollmentDate)
           {
            CourseId = courseId;
            RegistrationId = registrationId;
            EnrollmentDate = enrollmentDate;

           }
 

    
    }
}
