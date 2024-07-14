#pragma once
class Widget
{
public:
	void enable();
	void disable();
	//const state is defined, since we are not modifying the state of the object.
	//i.e. we cannot do widget.enable = false/true;
	bool isEnabled() const; 
private:
	bool enabled = false;

};

