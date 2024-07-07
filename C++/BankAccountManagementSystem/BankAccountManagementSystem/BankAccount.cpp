#include "BankAccount.h"
#include "Validator.h"
#include <iostream>
#include <iomanip>
#include <locale> // Add this header for setlocale
using namespace std;

// Set the locale to display the £ sign
void SetLocale() {
    setlocale(LC_ALL, "en_US.UTF-8");
}

BankAccount::BankAccount(string accountName, string accountNumber, Validator* validator) {
    this->accountHolder = accountName;
    this->accountNumber = accountNumber;
    this->balance = 0.0F;
    if (validator == nullptr) {
        BankAccount::validator = new Validator();
    }
}

bool BankAccount::Deposit(float depositAmount) {
    bool isPositiveBalance = validator->HasPositiveBalance(balance);
    cout << "Current Balance: " << fixed << setprecision(2) << this->balance << endl;

    if (isPositiveBalance) {
        SetLocale();
        
        cout << "Depositing: £" << fixed << setprecision(2) << depositAmount << endl;
        this->balance += depositAmount;
        return true;
    }
    else {
        throw runtime_error("Your balance is negative, please contact the bank and resolve this issue before depositing");
        return false;
    }
}

bool BankAccount::Withdraw(float withdrawAmount) {
    bool balanceHasSufficientFund = validator->HasSufficientFund(balance, withdrawAmount);
    cout << "Current balance: " << balance << endl;
    if (balanceHasSufficientFund) {
        SetLocale();
        
        cout << "Amount: £" << balance << endl;
        cout << "Withdrawing: £-" << withdrawAmount << endl;
        balance -= withdrawAmount;
        cout << "Balance after withdrawal: " << balance;
        return true;
    }
    else {
        cout << "Your account has insufficient funds. Balance: " + to_string(balance) + ", Withdrawn amount: " + to_string(withdrawAmount);
        return false;
    }
}
float BankAccount::GetCurrentBlance() {
    auto balance = this->balance;
    return balance;
}
void BankAccount::GetAccountInformation(){
	cout << "Account Holder: " << this->accountHolder << endl;
	cout << "Account Number: " << this->accountNumber << endl;
	cout << "Current Balance: " << this->balance << endl;
}
