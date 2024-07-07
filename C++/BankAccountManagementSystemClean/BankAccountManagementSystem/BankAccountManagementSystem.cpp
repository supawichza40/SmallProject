// BankAccountManagementSystem.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "BankAccount.h"
#include "Validator.h"
#include <iostream>
#include <string>
#include <windows.h>

int main()
{
    SetConsoleOutputCP(CP_UTF8);
    BankAccount* supaBankAccount = new BankAccount("Supa", "12345");
    // Depositing £100 -> should be okay and output and update balance to £100
    supaBankAccount->Deposit(100);
    // This will output a warning message due to insufficient fund.
    supaBankAccount->Withdraw(200);
    // This will output withdrawn message, because the withdrawn amount passed the validator, and you will see balance reduced.
    supaBankAccount->Withdraw(50);

}


