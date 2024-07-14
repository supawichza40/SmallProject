#include "TextBox.h"
#include <iostream>
#include <string>
using namespace std;
TextBox::TextBox(const std::string& content)
{
	this->content = content;
}
string TextBox::getValue()
{
	return this->content;
}

void TextBox::setValue(const string& value)
{
	this->content = value;
}
