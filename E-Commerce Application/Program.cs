using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using E_Commerce_Application;

class Program {

   // create list to store details
    static List<CustomerDetails> customerDetails = new List<CustomerDetails>();
    static List<ProductDeatils> productDetails = new List<ProductDeatils>();
    static List<OrderDetails> orderDetails = new List<OrderDetails>();

    // local variable for acsess curent user.
    static CustomerDetails currentCustomer;

    static OrderDetails currentOrder;
    static ProductDeatils currentProduct;
    public static void Main(string[] args){
        
        //greetings
        Console.WriteLine("                 SynCart");
        Console.WriteLine("E-Commerce Application for Buying Consumer Electronics Products");
           DefaultData();
        // method call to display options;
          MainMenu();

         
    }

      // method to display the options and select the option
     static void MainMenu(){
         
        
        Console.WriteLine("select the menu options below ");
        
        // 1 for registration 
        Console.WriteLine("1.Registration");
        // 2 for login
        Console.WriteLine("2.Login");
        // 2 for exit
        Console.WriteLine("3.Exit");
          
          //get user input to get choice
        int choice =int.Parse(Console.ReadLine());

           // swtich case for selected options
        switch(choice){
          
              // case 1 get the user to registration page
            case 1:{
                     Registration();
                     MainMenu();
                     break;
            }
            // case 2 get the user to login page
            case 2: {
                    CustomerLogin();
                     break;
            }
              // case 2 get the user to login page      
            case 3 : {    
                     ExitMenu();               
                     break;              
                 }
        }     
     }

            // method for registration form
    static void Registration(){
        /*  a.CustomerName
          b.City
          c.MobileNumber
          d.WalletBalance
          e.EmailID
          f.CustomerID (Auto-generated) */

        // get the user details
        Console.Write("Enter your FullName :");
           string name= Console.ReadLine();

           Console.Write("Enter your City :");
           string city= Console.ReadLine();

           Console.Write("Enter your MobileNumber :");
           string mobileNumber= Console.ReadLine();

           Console.Write("Enter your Email-Id :");
           string mailId= Console.ReadLine();

           CustomerDetails customer = new CustomerDetails(name,city,mobileNumber,mailId);
              customerDetails.Add(customer);
         
         Console.WriteLine($"Registration Successful. your Id :{customer.CustomerId}");  
        
    }

          static void CustomerLogin() {

        Console.Write("Enter your CustomerId :");
          // get the customerId
        string credentialId =Console.ReadLine().ToUpper();
        bool flag =true;

            // iterate the each customer datails
        foreach(CustomerDetails customer in customerDetails){
                 // verify the customerId matches
            if(credentialId.Equals(customer.CustomerId)){
                 flag = false;
                 currentCustomer = customer;
                 //if matches display the options
                 SubMenuOptions();
            }
        }       
           // if customerId not matches show prompt and ask to enter again
         if(flag){
                Console.WriteLine("Invalid User ID please reEnter the correct ID");
                CustomerLogin();
              }
          }


         // method for submenu Options
         static void SubMenuOptions(){
             // display the options
             Console.WriteLine("Select the options below");
           Console.WriteLine("1.Purchase");  
           Console.WriteLine("2.OrderHistory");
           Console.WriteLine("3.CancelOrder");
           Console.WriteLine("4.WalletBalance");
           Console.WriteLine("5.WalletRecharge");
           Console.WriteLine("6.Exit"); 

            int option = int.Parse(Console.ReadLine());
             

             // switch the user to the selected option
        switch(option){
            case 1 :{
                Purchase();
                SubMenuOptions();
                break;
            }
            case 2 : {
                OrderHistory();
                SubMenuOptions();
                break;
            }
            case 3 : {
                CancelOrder();
                SubMenuOptions();
                break;
            }

            case 4 : {
                DisplayWalletBalance();
                SubMenuOptions();

                break;
                 }
            case 5 : {
                WalletRecharge();
                SubMenuOptions();
                break;
                 } 
            case 6 : {
                SubExitMenu(); 
                break;
                 }  
                     
                 
            }  
         }


         static void Purchase(){
            foreach(ProductDeatils product in productDetails){
                 Console.WriteLine($"ProductID : {product.ProductId} ProductName : {product.ProductName} Stock : {product.Stock} Price : {product.Price} ShippingDuration : {product.ShippingDuration}");
                 Console.WriteLine();
            }
            Console.WriteLine("select the product with relevant id");

            string productId = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(ProductDeatils product in productDetails){
                if(productId.Equals(product.ProductId)){
                    
                    flag=false;
                    currentProduct=product;
                }
            }
            if(flag){
                Console.WriteLine("Invalid product Id ");
                Purchase();
            }

            Console.WriteLine("Enter how many items want to purchase in number ");
            int requiredCount = int.Parse(Console.ReadLine());

                if(currentProduct.ProductId.Equals(productId) && requiredCount<currentProduct.Stock){
                   double deliveryCharge = 50;
                  double totalAmount = (requiredCount * currentProduct.Price)+deliveryCharge;

                  Console.WriteLine("Your Bill Amount is "+totalAmount);

                  if(currentCustomer.WalletBalance>totalAmount){

                    currentCustomer.DeductAmount(totalAmount);
                    currentProduct.Stock-=requiredCount;

                    OrderDetails order = new OrderDetails(currentCustomer.CustomerId,currentProduct.ProductId,totalAmount,DateTime.Now,requiredCount,OrderStatus.Ordered);

                    orderDetails.Add(order);

                    Console.WriteLine($"Order Placed Successfully. Order ID: {order.OrderId} "); 
                    
                     
                  }
                  else {
                    Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do the purchase again");
                    SubMenuOptions();
                  }

                }
                else {
                    Console.WriteLine($"Required count not available. Current availability is {currentProduct.Stock}.");
                    Purchase();
                }

            
            CalculateOrderDate();   

         }

         public static void OrderHistory(){
            foreach(OrderDetails order in orderDetails){
                Console.WriteLine($"OrderID : {order.OrderId}   CustomerID : {order.CustomerId}   ProductID : {order.ProductId}	TotalPrice : {order.TotalPrice}	PurchaseDate : {order.PurchaseDate.ToString("dd/MM/yyyy")}	Quantity : {order.Quantity}	OrderStatus : {order.OrderStatus}");
                Console.WriteLine();
            }
         }

         public static void CancelOrder(){
            //display order details
            foreach(OrderDetails order in orderDetails){
                if(currentCustomer.CustomerId.Equals(order.CustomerId)){
                    Console.WriteLine($"OrderID :{order.OrderId}  CustomerID : {order.CustomerId}	ProductID :{order.ProductId}  TotalPrice : {order.TotalPrice}	PurchaseDate : {order.PurchaseDate}	Quantity : {order.Quantity}	OrderStatus : {order.OrderStatus}");
                }
                
                // ask the user to enter order id which want to cancel
                Console.WriteLine("Select the order Id you want cancel");
                string orderIdCancel =Console.ReadLine().ToUpper();
                bool flag = true;
                foreach(OrderDetails order1 in orderDetails){
                    if(orderIdCancel.Equals(order1.OrderId)){
                        flag = false;
                        currentOrder = order1;
                    }
                }
                    foreach(ProductDeatils product in productDetails){
                        if(currentOrder.ProductId.Equals(product.ProductId))
                        currentProduct = product;
                    }
                    currentProduct.Stock+=currentOrder.Quantity;
                        currentCustomer.AddWalletBalance(currentOrder.TotalPrice);
                        currentOrder.OrderStatus = OrderStatus.Cancelled;
                    Console.WriteLine($"Order:{currentOrder.OrderId} cancelled successfully.");
                    SubMenuOptions();
                    
                
                if(flag){
                    Console.WriteLine("Invalid OrderID");
                }
                
            }
         }

         static void DisplayWalletBalance(){
            Console.WriteLine($"your current balance is {currentCustomer.WalletBalance}");
         }

         static void CalculateOrderDate(){
 
                DateTime date = DateTime.Now;
                date = date.AddDays(currentProduct.ShippingDuration);

                Console.WriteLine($"Order placed successfully. Your order will be delivered on {date.ToString("dd/MM/yyyy")},{currentProduct.ShippingDuration} Days.");
            
        }

         static void WalletRecharge(){
            Console.WriteLine("Do you want to recharge the wallet :");
            string choice = Console.ReadLine().ToLower();
            if(choice=="yes"){
            Console.Write("Enter the Amount :");
            double amount = double.Parse(Console.ReadLine());
            currentCustomer.AddWalletBalance(amount);
                }
                Console.WriteLine("Your money is added sucessfully4");
              }

        
        public static void DefaultData(){
               
             // add default customer details  
            CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai","9885858588","ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai","9888475757","baskaran@mail.com");
            customerDetails.Add(customer1);
            customerDetails.Add(customer2);

            // add default Product details

            ProductDeatils product1 = new ProductDeatils("Mobile(Samsung)",10,10000,3);
            ProductDeatils product2 = new ProductDeatils("Tablet(Lenovo)",5,15000,2);
            ProductDeatils product3 = new ProductDeatils("Camara(Sony)",3,20000,4);
            ProductDeatils product4 = new ProductDeatils("iPhone",5,50000,6);
            ProductDeatils product5 = new ProductDeatils("Laptop(Lenovo I3)",3,40000,3);
            ProductDeatils product6 = new ProductDeatils("HeadPhone(Boat)",	5,1000,2);
            ProductDeatils product7 = new ProductDeatils("Speakers(Boat)",4,500,2);

            productDetails.Add(product1);
            productDetails.Add(product2);
            productDetails.Add(product3);
            productDetails.Add(product4);
            productDetails.Add(product5);
            productDetails.Add(product6);
            productDetails.Add(product7);

            // add default OrderDetails details

            OrderDetails order1= new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,OrderStatus.Ordered);
            OrderDetails order2= new OrderDetails("CID1002","PID103",40000,DateTime.Now,2,OrderStatus.Ordered);

            orderDetails.Add(order1);
            orderDetails.Add(order2);
            }

             static void ExitMenu(){
                // ask the user to confirm the exit
            Console.WriteLine("Do you want Exit (yes or no)");
            string check = Console.ReadLine().ToLower();
            //verify the choice to exit or get to the mainmenu
            if(check=="no"){
                MainMenu();
            }
            else {
                
            }
            
        }
        // method for exit option in sub menu
        static void SubExitMenu(){
            // ask the user to confirm the exit in submenu
            Console.WriteLine("Do you want Exit (yes or no)");
            // user input
            string check = Console.ReadLine().ToLower();
            // verify the choice and get to the page or exit
            if(check=="yes"){
                MainMenu();
            }
            else{
                SubMenuOptions();
            }
            
        } 
            

          }
       
 
    