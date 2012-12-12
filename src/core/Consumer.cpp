#include "Consumer.h"

Consumer::Consumer(const std::string& name)
: m_name(name)
, m_credit(0.f)
{
}

std::string Consumer::getName() const
{
	return m_name;
}

float Consumer::getCredit() const
{
	return m_credit;
}

void Consumer::deposit(float amount)
{
	m_credit += amount;
}

void Consumer::withdraw(float amount)
{
	m_credit -= amount;
}
