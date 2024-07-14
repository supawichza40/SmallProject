#include "Widget.h"

void Widget::enable()
{
    this->enabled = true;
}

void Widget::disable()
{
    //this-> when we refer to a pointer to an object, we use this-> to access members of the object.
    //this. when we refer to an object(reference to the object), we use this. to access members of the object.
    this->enabled = false; // this-> is used to access members of an object through a pointer.
    // this-> refers to specific instance of the object.

}

bool Widget::isEnabled() const
{
    return this->enabled;
}
