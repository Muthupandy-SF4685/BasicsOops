using System;

namespace OnlineCourseEnrollment
{
   /// <summary>
   /// Used to select a gender information
   /// </summary>
    public enum Gender{select,male,female}

    /// <summary>
    ///  class <see cref="UserDetails"/> used to collect user's details for the enrollment process
    /// </summary>
    public class UserDetails
    {

    /// <summary>
    /// static field used to auto increament and it uniquely  identify an instance of
    /// </summary>
    private static int s_RegistrationId =1000; //static field


    // properties
    /// <summary>
    /// property RegistrationId used to get registration Id of the user
    /// </summary>
    /// <value></value>
    public string RegistrationId {get;}  //read only property
    
    /// <summary>
    /// property Name used to get name of the user
    /// </summary>
    /// <value></value>
    public string Name{ get; set;}
    /// <summary>
    /// property Age used to get age of the user
    /// </summary>
    /// <value></value>
    public int Age { get; set;}
     /// <summary>
     /// property GenderType used to get gender of the user
     /// </summary>
     /// <value></value>
    public Gender GenderType{get; set;}
    /// <summary>
    /// property Qualification used to get qualification of the user
    /// </summary>
    /// <value></value>
    public string Qualification { get; set;}
    /// <summary>
    /// property PhoneNumber used to get phone number of the user
    /// </summary>
    /// <value></value>
    
    public string PhoneNumber{get; set;}
    
    /// <summary>
    /// property MailId used to get mail id of the user
    /// </summary>
    /// <value></value>
    public string MailId{get; set;}
   

   
     /// <summary>
     /// Constructor of <see cref="UserDetails"/> class used to intialize values to its properties
     /// </summary>
     /// <param name="name">parameter Name used to initialize user's name  to Name property</param>
     /// <param name="age">parameter age used to initialize user's age  to age property</param>
     /// <param name="genderType">parameter GenderType used to initialize user's gender to the gender property</param>
     /// <param name="qualification">parameter Qualification used to initialize user's qualification  to qualification property</param>
     /// <param name="mailId">parameter mail-id used to initialize user's mailid  to mail id property</param>
     /// <param name="phoneNumber">parameter phoneNumber used to initialize user's phone number  to the property</param>  
     
    public UserDetails( string name,int age,Gender genderType,string qualification,string mailId,string phoneNumber){

        s_RegistrationId++;
        RegistrationId = "SYNC"+ s_RegistrationId;
        Name= name;
        GenderType=genderType;
        MailId=mailId;
        PhoneNumber =phoneNumber;      

    }
         


        
    }
}
