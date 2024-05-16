using System;

namespace BankAccountOpening

{     // create enum for Gender    
    public enum Gender {Select,Male,Female}
    public class AccountDetails
    {
          // static variable for customer id
        private static int s_customerId = 1000;

        // static variable for customerbalance
        private static double s_balanceAmount = 0;

        // Customer Id -(HDFC1001), Customer name, Balance, 
        // Gender (enum), Phone, Mail Id, Date of Birth
         
        //properties 

        public string CustomerId {get;}
        public string CustomerName {get; set;}
        public double BalanceAmount{get;}
        public Gender Gender{get; set;}

        public string PhoneNumber {get; set;}
        public string MailId {get; set;}

        public DateTime DateOfBirth {get; set;}

        

         // constructor to intialize to properties
         public AccountDetails(string name,Gender gender, string phoneNumber,string mailId,DateTime dateOfBirth )
         {       // increament the customerId
                 s_customerId++;
                 // generate the customerId
                 CustomerId = "HDFC" + s_customerId;
                 CustomerName =name;
                 Gender = gender;
                 PhoneNumber = phoneNumber;
                 MailId = mailId;
                 DateOfBirth = dateOfBirth;
                 BalanceAmount = s_balanceAmount;

         }
            
            //method for deposit
           public double Deposit(double depositAmount){

               // add the deposited amount to the balance
              s_balanceAmount +=depositAmount;
                  
              return s_balanceAmount;
           }
 
             // method for withdrawal
            public void Withdraw()
           {
              
              // if yes display the balanceAmount
              if(check=="yes"){
              s_balanceAmount-=withDrawAmount;
              Console.WriteLine("Current BalanceAmount :" +s_balanceAmount);
              }

           }
             // method for balancecheck
           public void BalanceCheck(){
              Console.WriteLine("Current BalanceAmount :"+ s_balanceAmount);
           }

           


    }


}
