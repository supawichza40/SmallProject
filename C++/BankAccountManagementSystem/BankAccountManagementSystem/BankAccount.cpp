#include "BankAccount.h"
#include "Validator.h"
#include <iostream>
#include <iomanip>
using namespace std;
BankAccount::BankAccount(string accountName, string accountNumber,Validator* validator) {
	this->accountHolder = accountName;
	this->accountNumber = accountNumber;
	this->balance = 0.0F;
	if (validator == nullptr)
	{
		BankAccount::validator = new Validator();
	}
	
}

bool BankAccount::Deposit(float depositAmount)
{
	bool isPositiveBalance = validator->HasPositiveBalance(balance);
	cout << "Current Balance: " << fixed << setprecision(2) << this->balance << endl;

	if (isPositiveBalance)
	{
		cout << "Depositing: £" << fixed << setprecision(2) << depositAmount << endl;
		this->balance += depositAmount;
		return true;
	}
	else {
		cout << "You balance is negative, please contact the bank and resolve this issue, before depositing" << endl;
		return false;
	}

}

bool BankAccount::Withdraw(float withdrawAmount)
{
	bool balanceHasSufficientFund = validator->HasSufficientFund(balance, withdrawAmount);
	cout << "Current balance: " << balance << endl;
	if (balanceHasSufficientFund)
	{
		cout << "Amount: £" << balance << endl;
		cout << "Withdrawing :£-" << withdrawAmount << endl;
		balance -= withdrawAmount;
		cout << "Balanc after withdrawn: " << balance;
		return true;
	}
	else {
		cout << "Your account has insufficient fund Balance: " << balance << " Withdrawn amount" << withdrawAmount << endl;
		cout << "Please deposit more fund into your account" << endl;
		return false;
	}
}
