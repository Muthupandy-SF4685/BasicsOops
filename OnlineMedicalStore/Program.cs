using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace OnlineMedicalStore;

public class Program {
   
   static List<UserDetails> userDetails = new List<UserDetails>();
   static List<OrderDetails> orderDetails = new List<OrderDetails>();
   static List<MedicineDetails> medicineDetails = new List<MedicineDetails>();

   public static MedicineDetails CurrentMedicine;
   public static UserDetails currentUser;
   public static OrderDetails currentOrder;

    public  static void Main(string[] args){

        Console.WriteLine("Online Medical Store");
        DefaultDate();


    }

    static void Mainmenu(){
        Console.WriteLine("select the options below");
        Console.WriteLine("1.Registration");
        Console.WriteLine("2.login");
        Console.WriteLine("3.Exit");

        int options = int.Parse(Console.ReadLine());
        switch(options){

            case 1: {
                Registration();
                break;
            }
            case 2 : {
                break;
            }
            case 3 : {
                break;
            }
        }
    }

      static void Registration(){
        
        Console.Write("Enter your Full Name : ");
        string name = Console.ReadLine();
        
        Console.Write("Enter your age : ");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("Enter your city : ");
        string city =Console.ReadLine();
        
        Console.Write("Enter your PhoneNumber : ");
        string phoneNumber = Console.ReadLine();
        
        UserDetails user = new UserDetails(name,age,city,phoneNumber);
        userDetails.Add(user);

        Console.WriteLine($"your Registration is successful . Your ID is {user.UserId}");

      }

      static void UserLogin(){

        Console.Write("Enter your UserId :");
        string userCredentialId = Console.ReadLine();
        bool flag = true;
        foreach(UserDetails user in userDetails){
            if(user.UserId.Equals(userCredentialId)){
                 flag = false;
                 SubMenuOptions();
            }
        }
        while(flag){
            Console.Write("Invalid userId please enter correct Id :");
             userCredentialId = Console.ReadLine();
             flag = true;
             foreach(UserDetails user in userDetails){
            if(user.UserId.Equals(userCredentialId)){
                 flag = false;
                 currentUser = user;
                 SubMenuOptions();
            }

        }
      }

      }
  // method for sub mmenu
      static void SubMenuOptions(){
              Console.WriteLine("select the options below");
              Console.WriteLine("1.Show medicine list.");
              Console.WriteLine("2.Purchase medicine");
              Console.WriteLine("3.Cancel purchase.");
              Console.WriteLine("4.Show purchase history.");
              Console.WriteLine("5.Recharge");
              Console.WriteLine("6.Show WalletBalance");
              Console.WriteLine("7.Exit");

              int choice = int.Parse(Console.ReadLine());

              switch(choice){

                case 1: {
                    ShowMedicineData();

                    break;
                }
                case 2: {
                    PurchaseMedicine();
                    break;
                }
                case 3: {
                    CancelMedicine();
                    break;
                }
                case 4: {
                    break;
                }
                case 5: {
                    break;
                }
                case 6: {
                    break;
                }
                case 7: {
                    break;
                }



              }

      }

      static void ShowMedicineData(){
        foreach(MedicineDetails medicine in medicineDetails){
            Console.WriteLine($"MedicineID : {medicine.MedicineId}	MedicineName : {medicine.MedicineName}	AvailableCount : {medicine.AvailableCount}	PriceDateOfExpiry : {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
        }
      }
          
          // method for purchase medicine
      static void PurchaseMedicine(){
        ShowMedicineData();
        Console.WriteLine("Enter the Medicine Id you want purchase :");
        string medicineId = Console.ReadLine();
        System.Console.WriteLine("Enter the count of the medicine you want to buy:");
         int countOfMedicine = int.Parse(Console.ReadLine());
            bool flag = true;
         foreach(MedicineDetails medicine in medicineDetails){
            if(medicine.MedicineId.Equals(medicineId)){
                flag = false;
                CurrentMedicine = medicine;
         }
      
      }
      if(countOfMedicine<CurrentMedicine.AvailableCount){
                    if(CurrentMedicine.DateOfExpiry>DateTime.Now){
                     double amount = CurrentMedicine.Price*countOfMedicine;
                     double balance = currentUser.BalanceDisplay();
                     if(amount>balance){

                          CurrentMedicine.AvailableCount-=countOfMedicine;
                            balance-=amount;

                            OrderDetails order1 = new OrderDetails(currentUser.UserId,CurrentMedicine.MedicineId,countOfMedicine,amount,DateTime.Now,OrderStatus.Purchased);
                            orderDetails.Add(order1);

                            Console.WriteLine($"Medicine was purchased successfully. your OrderId is : {order1.OrderId}");

                     }else {
                        Console.WriteLine("Not available balance");
                     }


                    }else {
                    Console.WriteLine("Medicine is not available");
                    

                }
                

            }
      }

      static void CancelMedicine(){

      }
      static void ShowPurchaseHistory(){
        foreach(OrderDetails order in orderDetails){}
      }

    static void DefaultDate(){

        //default data for user
          
          UserDetails user1 = new UserDetails("Ravi",33,"Theni","9877774440");
          UserDetails user2 = new UserDetails("Baskaran",33,"Chennai","8847757470");

          userDetails.Add(user1);
          userDetails.Add(user2);
          
        // default data for medicine
        MedicineDetails medicine1 = new MedicineDetails("Paracitamol",40,5,new DateTime(2023,12,30));
        MedicineDetails medicine2 = new MedicineDetails("Calpol",10,5,new DateTime(2023,11,30));
        MedicineDetails medicine3 = new MedicineDetails("Gelucil",3,40,new DateTime(2025,04,30));
        MedicineDetails medicine4 = new MedicineDetails("Metrogel",5,50,new DateTime(2024,12,30)); 
        MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin",10,50,new DateTime(2026,10,30));

        medicineDetails.Add(medicine1);
        medicineDetails.Add(medicine2);
        medicineDetails.Add(medicine3);
        medicineDetails.Add(medicine4);
        medicineDetails.Add(medicine5);
        
        //default data for order
        OrderDetails order1 = new OrderDetails("UID1001","MD2001",3,15,new DateTime(2023,11,13),OrderStatus.Purchased);
        OrderDetails order2 = new OrderDetails("UID1001","MD2002",2,10,new DateTime(2023,11,13),OrderStatus.Cancelled);
        OrderDetails order3 = new OrderDetails("UID1001","MD2004",2,100,new DateTime(2023,11,13),OrderStatus.Purchased);
        OrderDetails order4 = new OrderDetails("UID1002","MD2003",3,120,new DateTime(2024,01,15),OrderStatus.Cancelled);
        OrderDetails order5 = new OrderDetails("UID1002","MD2005",5,250,new DateTime(2024,01,15),OrderStatus.Purchased);
        OrderDetails order6 = new OrderDetails("UID1002","MD2002",3,15,new DateTime(2024,01,15),OrderStatus.Purchased);

        orderDetails.Add(order1);
        orderDetails.Add(order2);
        orderDetails.Add(order3);
        orderDetails.Add(order4);
        orderDetails.Add(order5);
        orderDetails.Add(order5);
    }

}