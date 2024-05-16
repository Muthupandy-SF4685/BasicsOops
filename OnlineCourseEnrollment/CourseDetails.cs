using System;
using System.Dynamic;

namespace OnlineCourseEnrollment
{

    /// <summary>
    /// class <see cref="CourseDetails"/> used to collect course details for display process
    /// </summary>
    public class CourseDetails
    
    {       
             /// <summary>
             /// static field used to auto increament and it uniquely  identify an instance of
             /// </summary>
            private static int s_CourseId =2000;
        
            /// <summary>
            /// property CourseId used to get course Id's
            /// </summary>
            /// <value>It allows only string value</value>
            public string CourseId {get;}

            /// <summary>
            /// property CourseName used to get course of the name
            /// </summary>
            /// <value>It allows only string value</value>
            public string CourseName {get; set;}

            /// <summary>
            /// property TrainerName used to get trainer's Name
            /// </summary>
            /// <value>It allows only string value</value>
            public string TrainerName {get; set;}

            /// <summary>
            /// property CourseDuration used to get duration of the course
            /// </summary>
            /// <value>It allows only integer value</value>
            public int CourseDuration {get; set;}

            /// <summary>
            /// property SeatsAvailable used to get seats available of the course
            /// </summary>
            /// <value>It allows only integer value</value>
            public int SeatsAvailable {get; set;}


            /// <summary>
            /// Constructor of <see cref="CustomerDetails"/> class used to intialize values to its properties
            /// </summary>
            /// <param name="courseName">parameter customer name used to initialize customer's name  to Name property</param>
            /// <param name="trainerName">parameter customer name used to initialize customer's name  to Name property</param>
            /// <param name="courseDuration">parameter customer name used to initialize customer's name  to Name property</param>
            /// <param name="seatsAvailabe">parameter customer name used to initialize customer's name  to Name property</param>

            public CourseDetails (string courseName,string trainerName,int courseDuration,int seatsAvailabe)
           {
            s_CourseId+=1;
            CourseId = "CS" +s_CourseId;
            CourseName = courseName;
            TrainerName = trainerName;
            CourseDuration = courseDuration;
            SeatsAvailable = seatsAvailabe;
        }
    }
}
