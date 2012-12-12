#pragma once

#include <string>

class Consumer
{
public:
	Consumer(const std::string& name);

	std::string getName() const;
	float getCredit() const;
	void deposit(float amount);
	void withdraw(float amount);

private:
	std::string m_name;
	float m_credit;
};
