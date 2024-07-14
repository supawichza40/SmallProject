#pragma once
#include "Widget.h"
#include <string>
using namespace std;
class TextBox :
    public Widget //the we said "public" on a widget, we will inherit public members of the widget.
    // if we set this to private, all public members of the widget will be private in the TextBox class.
    // only the TextBox class can access the public members of the widget. and not the outside world.
    // 99% of the time, we will use public.
{
public:
    TextBox() = default; //Empty constructor that does not perform any specific actions or initialization.
    explicit TextBox(const std::string& content); //explicit keyword is used to prevent implicit conversion of the constructor.
    //Implicit conversion is when the compiler automatically converts one type to another type.
    //Implicit example: int x = 5.0; //5.0 is a double, but it is implicitly converted to an int.
    //Without explicit we can do TextBox box = "Hello"; //This is a string, but it is implicitly converted to a TextBox.
    //With explicit we cannot do TextBox box = "Hello"; //This is a string, but it is not implicitly converted to a TextBox.
    string getValue();
    void setValue(const string& value); //const string& value is a reference to a constant string.
    // By passing string& instead of string, we are passing a reference to the string, not the actual string.
    // We are going to pass by reference and not by value, because passing by value will create a copy of the string.
    //This means that the string value passed to the parameter cannot be modified.
private:
    string content = "";
};

