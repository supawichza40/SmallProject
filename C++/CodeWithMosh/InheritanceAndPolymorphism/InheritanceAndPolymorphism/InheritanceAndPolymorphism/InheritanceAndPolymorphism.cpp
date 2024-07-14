// InheritanceAndPolymorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
#include <string>;
#include "InheritanceAndPolymorphism.h"
#include "TextBox.h";
void Test(string& str)
{
    // Appending "King" to the string.
    str += " King";
    cout << str << endl;
}
void Test2(const string& str) {

}
void PointerAndAddressExample()
{
    int i = 10;
    cout << "i =" << i << endl;
    int* p = &i; // p is a pointer to i. P stores the address of i by use a int* pointer and holding the address of i.
    //* is the pointer of a variable. Pointer will hold the address of the variable.
    //The pointer p gets assigned the address of i by using the & operator.
    i = 20;
    cout << "i =" << i << endl;
    cout << "p =" << p << endl;
    cout << "*p =" << *p << endl;

    string str = "Hello World";
    string* pStr = &str;
    string* pStr2 = pStr;

    cout << "str =" << str << endl;
    cout << "pStr =" << pStr << endl;
    *pStr2 = "Hello C++";
    cout << "str =" << str << endl;
    cout << "pStr =" << pStr << endl;
    cout << "*pStr =" << *pStr << endl;

    Test(str);
}
int main()
{
    // 1. Pointer *, address of &, dereference *
    // 2. Inheritance
    // Print the option above, so the user knows what to do.
    cout<< "1. Pointer *, address of &, dereference *" << endl;
    cout << "2. Inheritance" << endl;   
    cout << "Enter the number of the option you want to run: ";
    int option;
    cin >> option;  
    //Switch statement to run the option the user selected.
    switch (option)
	{
        case 1:
		PointerAndAddressExample();
		break;
        case 2:
		{
			TextBox box;
			box.enable();
			cout << "Is enabled: " << box.isEnabled() << endl;
			box.disable();
			cout << "Is enabled: " << box.isEnabled() << endl;
			box.setValue("Hello World");
			cout << "Value: " << box.getValue() << endl;
		}
		break;
		default:
			cout << "Invalid option" << endl;
			break;
	}
	return 0;
    

    
}



// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
