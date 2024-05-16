using System;

namespace E_Commerce_Application
{

  /// <summary>
  /// class <see cref="CustomerDetails"/> used to collect customer's details for the purchase order process
  /// </summary>
    public class CustomerDetails
    {

      /// <summary>
      /// static field used to auto increament and it uniquely  identify an instance of
      /// </summary>
      // static field for customerid
      private static int s_CustomerId = 0;

      /// <summary>
      /// field used to maintain balance privately
      /// </summary>
      private double _WalletBalance=0;

        
           
           /// <summary>
           ///  property CustomerId used to get customer's Id
           /// </summary>
           /// <value>It allows only string type of value</value>
             //property
          public string CustomerId  {get;}

          /// <summary>
          ///  property CustomerName used to get Customer's Name
          /// </summary>
          /// <value>It allows only string type of value</value>
          public string CustomerName {get; set;}

          /// <summary>
          ///  property City used to get customer's city
          /// </summary>
          /// <value>It allows only string type of value</value>
          public string City {get; set;}

          /// <summary>
          ///  property MobileNumber used to get customer's mobile number
          /// </summary>
          /// <value>It allows only string type of value</value>
          public string MobileNumber {get; set;}

          /// <summary>
          ///  property WalletBalance used to get customer's wallet balance
          /// </summary>
          /// <value>It allows only double type of value</value>
          public double WalletBalance {get{return _WalletBalance;}}

          /// <summary>
          /// property EmailId used to get customer's email id
          /// </summary>
          /// <value>It allows only string type of value</value>
          public string EmailId {get; set;}
        
     /// <summary>
     /// Constructor of <see cref="CustomerDetails"/> class used to intialize values to its properties
     /// </summary>
     /// <param name="customerName">parameter customer name used to initialize customer's name  to Name property</param>
     /// <param name="city">parameter city used to initialize customer's city to City property</param>
     /// <param name="mobileNumber">parameter mobileNumber used to initialize Customer's  MobileNumber property</param>
     /// <param name="walletBalance">parameter walletBalance used to initialize customer's WalletBalance property</param>
     /// <param name="emailId">parameter emailId used to initialize customers's Emailid property</param>
     public CustomerDetails (string customerName,string city,string mobileNumber,string emailId){
        
       s_CustomerId++;
       CustomerId = "CID"+s_CustomerId;
       CustomerName = customerName;
       City = city;
       MobileNumber = mobileNumber;
       EmailId = emailId;
     }

     /// <summary>
     /// method to add amount to currentwallet
     /// </summary>
     /// <param name="amount">parameter amount used to initialize customer's deposited amount</param>
     public void AddWalletBalance(double amount){

      _WalletBalance+=amount;
     }

    /// <summary>
    /// method to deduct amount from the customer
    /// </summary>
    /// <param name="amount">parameter amount used to initialize customer's deducted amount</param>
     public void DeductAmount(double amount){
      _WalletBalance-=amount;
     }
        
    }
}
