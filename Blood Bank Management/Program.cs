using System;
using Blood_Bank_Management;

namespace BloodBankManagement;

class Program {
    public static void Main(string[] args){

        Operations.AddDefaultData();
        Operations.MainMenu();

    }
}