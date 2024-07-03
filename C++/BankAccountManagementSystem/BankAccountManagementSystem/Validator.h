#pragma once
class Validator
{
public:
	bool HasPositiveBalance(float balance);
	bool HasSufficientFund(float balance, float withdrawnAmount);
};

