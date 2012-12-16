#include "Session.h"
#include "Consumer.h"
#include "Inventory.h"
#include <algorithm>
#include <cassert>
#include <ctime>
#include <cstring>

Session::Session()
: m_consumed(new Inventory)
{
	m_time = time(NULL);
}

Session::Session(int year, int month, int day)
: m_consumed(new Inventory)
{
	tm t;
	memset(&t, 0, sizeof(tm));

	t.tm_year = year - 1900;
	t.tm_mon = month - 1;
	t.tm_mday = day;
	t.tm_isdst = -1;

	m_time = mktime(&t);

	assert(m_time != -1);	// The date is too far in the future, overflowing 32-bit time_t
}

Session::~Session()
{
	delete m_consumed;
}

void Session::addConsumer(Consumer* consumer)
{
	assert(std::find(m_consumers.begin(), m_consumers.end(), consumer) == m_consumers.end());

	// Unset credits
	for (int i = 0; i < m_consumed->getAllCount(); ++i)
	{
		float price = m_consumed->getItemPrice(i) / m_consumers.size();
		for (consumers_t::iterator c = m_consumers.begin(); c != m_consumers.end(); ++c)
			(*c)->deposit(price);
	}

	m_consumers.push_back(consumer);

	// Reset credits
	for (int i = 0; i < m_consumed->getAllCount(); ++i)
	{
		float price = m_consumed->getItemPrice(i) / m_consumers.size();
		for (consumers_t::iterator c = m_consumers.begin(); c != m_consumers.end(); ++c)
			(*c)->withdraw(price);
	}
}

void Session::removeConsumer(Consumer* consumer)
{
	consumers_t::iterator it = std::find(m_consumers.begin(), m_consumers.end(), consumer);
	assert(it != m_consumers.end());

	// Unset credits
	for (int i = 0; i < m_consumed->getAllCount(); ++i)
	{
		float price = m_consumed->getItemPrice(i) / m_consumers.size();
		for (consumers_t::iterator c = m_consumers.begin(); c != m_consumers.end(); ++c)
			(*c)->deposit(price);
	}

	m_consumers.erase(it);

	// Reset credits
	for (int i = 0; i < m_consumed->getAllCount(); ++i)
	{
		float price = m_consumed->getItemPrice(i) / m_consumers.size();
		for (consumers_t::iterator c = m_consumers.begin(); c != m_consumers.end(); ++c)
			(*c)->withdraw(price);
	}
}

int Session::getConsumerCount() const
{
	return m_consumers.size();
}

std::string Session::getConsumerName(int index) const
{
	assert(index >= 0 && index < m_consumers.size());

	return m_consumers[index]->getName();
}

bool Session::isBefore(const Session* other) const
{
	return m_time < other->m_time;
}

bool Session::isAfter(const Session* other) const
{
	return m_time > other->m_time;
}

void Session::consumeFrom(Inventory* inventory, const std::string& item)
{
	float price = inventory->getHighestPrice(item);
	inventory->removeHighestPrice(item);
	m_consumed->add(1, item, price);
}

void Session::unconsumeTo(Inventory* inventory, const std::string& item)
{
	float price = m_consumed->getLowestPrice(item);
	m_consumed->removeLowestPrice(item);
	inventory->add(1, item, price);
}

int Session::getConsumedCount() const
{
	return m_consumed->getAllCount();
}
