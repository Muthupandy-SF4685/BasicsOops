using System;

namespace EB_BillCalculation
{
    public class EbBillDetails
    
    {
         //static field
        private static int s_meterId =1000; //
        private static int s_EbBillAmount =0;
        private static int s_unitsUsed =0;
        //properties
        // Properties - Meter ID -(EB1001), Username, Phone number, Mail id, Units Used =0
        public string MeterId {get; }  // read only
        public int EbBillAmout {get; set;}
        public string UserName {get; set;}
        public string PhoneNumber {get; set;}
        public string MailId {get; set;}
        public int UnitsUsed {get;}

             // constructor for the properties
        public EbBillDetails(string userName,string phoneNumber, string mailId){
            
            // increament meter id every iteration 
            s_meterId+=1;
            // generate merterid
            MeterId = "EB" + s_meterId;
            UserName = userName;
            PhoneNumber = phoneNumber;
            MailId = mailId;


        }
 
             // method for calculate amount
        public void CalculateAmount(){
             // ask the user to enter the units used
            Console.Write("Enter the units details:");
            s_unitsUsed = int.Parse(Console.ReadLine());

            Console.WriteLine();
             // calculate and asign the amount in bill
            s_EbBillAmount= s_unitsUsed*5; //per unit Rs.5
 
             //  display the amount
            Console.WriteLine("Bill Amount = RS."+s_EbBillAmount);
            Console.WriteLine();

        }
    }
}
