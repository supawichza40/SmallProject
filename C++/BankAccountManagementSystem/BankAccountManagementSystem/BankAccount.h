#pragma once
#include <string>
#include "Validator.h"
using namespace std;
class BankAccount
{
	// camelCasing
	// Attributes
	public:
		string accountHolder;
		string accountNumber;
		float balance;
		Validator* validator;



	//Methods
	//Will force anyone using this class to provide name and account number
public:
	BankAccount(string accountName, string accountNumber,Validator* validator=nullptr);

	bool Deposit(float depositAmount);

	bool Withdraw(float withdrawAmount);


};

