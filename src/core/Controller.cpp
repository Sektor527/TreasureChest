#include "Controller.h"
#include "Session.h"
#include "Consumer.h"
#include <cassert>

void Controller::addSession(int year, int month, int day)
{
	Session* session = new Session(year, month, day);

	std::vector<Session*>::iterator it;
	for (it = _sessions.begin(); it != _sessions.end(); ++it)
	{
		if (session->isBefore(*it))
		{
			_sessions.insert(it, session);
			break;
		}
	}

	if (it == _sessions.end())
		_sessions.push_back(session);
}

void Controller::removeSession(int session)
{
	assert(session >= 0 && session < _sessions.size());

	_sessions.erase(_sessions.begin() + session);
}

int Controller::getSessionCount() const
{
	return _sessions.size();
}

int Controller::getSession(int year, int month, int day) const
{
	Session target(year, month, day);

	std::vector<Session*>::const_iterator it;
	for (it = _sessions.begin(); it != _sessions.end(); ++it)
	{
		Session* session = *it;
		if (session->isEqual(&target)) return std::distance(_sessions.begin(), it);
	}
	
	assert(false);
	return -1;
}

void Controller::addConsumer(const std::string& name)
{
	_consumers.push_back(new Consumer(name));
}

int Controller::getConsumerCount() const
{
	return _consumers.size();
}

void Controller::removeConsumer(int consumer)
{
	assert(consumer >= 0 && consumer < _consumers.size());

	_consumers.erase(_consumers.begin() + consumer);
}

std::string Controller::getConsumerName(int consumer) const
{
	assert(consumer >= 0 && consumer < _consumers.size());
	
	return _consumers[consumer]->getName();
}

int Controller::getConsumer(const std::string& name) const
{
	std::vector<Consumer*>::const_iterator it;
	for (it = _consumers.begin(); it != _consumers.end(); ++it)
	{
		Consumer* consumer = *it;
		if (consumer->getName() == name) return std::distance(_consumers.begin(), it);
	}

	assert(false);
	return -1;
}

void Controller::depositCredit(int consumer, float credit)
{
	assert(consumer >= 0 && consumer < _consumers.size());
	
	_consumers[consumer]->deposit(credit);
}

float Controller::getConsumerCredit(int consumer) const
{
	assert(consumer >= 0 && consumer < _consumers.size());
	
	return _consumers[consumer]->getCredit();
}

void Controller::addConsumerToSession(int session, int consumer)
{
	assert(session >= 0 && session < _sessions.size());

	_sessions[session]->addConsumer(_consumers[consumer]);
}

void Controller::removeConsumerFromSession(int session, int consumer)
{
	assert(session >= 0 && session < _sessions.size());

	Session* s = _sessions[session];
	Consumer* c = _consumers[consumer];
	for (int i = 0; i < s->getConsumerCount(); ++i)
	{
		if (s->getConsumerName(i) == c->getName())
		{
			s->removeConsumer(i);
			return;
		}
	}
	
	assert(false);
}

bool Controller::isConsumerInSession(int session, int consumer) const
{
	assert(session >= 0 && session < _sessions.size());
	assert(consumer >= 0 && consumer < _consumers.size());

	Consumer* c = _consumers[consumer];
	Session* s = _sessions[session];

	for (int i = 0; i < s->getConsumerCount(); ++i)
	{
		if (s->getConsumerName(i) == c->getName()) return true;
	}

	return false;
}

void Controller::addItemToInventory(int count, const std::string& name, float value, int units)
{
	_inventory.add(count, name, value, units);
}

void Controller::removeItemFromInventory(const std::string& name)
{
	_inventory.removeLowestPrice(name);
}

int Controller::getItemCount() const
{
	return _inventory.getAllCount();
}

int Controller::getItemGroupCount() const
{
	return _inventory.getItemGroupCount();
}

std::string Controller::getItemGroupName(int index) const
{
	return _inventory.getItemGroupName(index);
}

int Controller::getItemCount(int index) const
{
	return _inventory.getItemCount(index);
}

int Controller::getItemCount(const std::string& name) const
{
	return _inventory.getItemCount(name);
}

void Controller::consumeItem(int session, int item)
{
	assert(session >= 0 && session < _sessions.size());
	assert(item >= 0 && item < _inventory.getItemGroupCount());

	Session* s = _sessions[session];
	s->consumeFrom(&_inventory, getItemGroupName(item));
}

void Controller::unconsumeItem(int session, int item)
{
	assert(session >= 0 && session < _sessions.size());
	assert(item >= 0 && item < _inventory.getItemGroupCount());

	Session* s = _sessions[session];
	s->unconsumeTo(&_inventory, getItemGroupName(item));
}

int Controller::getSessionItemGroupCount(int session) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumed()->getItemGroupCount();
}

std::string Controller::getSessionItemGroupName(int session, int index) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumed()->getItemGroupName(index);
}

int Controller::getSessionItemCount(int session, int index) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumed()->getItemCount(index);
}

int Controller::getSessionItemCount(int session, const std::string& name) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumed()->getItemCount(name);
}
