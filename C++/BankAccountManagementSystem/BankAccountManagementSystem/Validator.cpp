#include "Validator.h"

bool Validator::HasPositiveBalance(float balance) {
	if (balance>=0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool Validator::HasSufficientFund(float balance, float withdrawnAmount)
{
	if (balance>=withdrawnAmount)
	{
		return true;
	}

	return false;
}
