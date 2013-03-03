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

void Controller::removeSession(int sessionID)
{
	assert(sessionID >= 0 && sessionID < _sessions.size());

	_sessions.erase(_sessions.begin() + sessionID);
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

void Controller::removeConsumer(int consumerID)
{
	assert(consumerID >= 0 && consumerID < _consumers.size());

	_consumers.erase(_consumers.begin() + consumerID);
}

std::string Controller::getConsumerName(int consumerID) const
{
	assert(consumerID >= 0 && consumerID < _consumers.size());
	
	return _consumers[consumerID]->getName();
}

void Controller::depositCredit(int consumerID, float credit)
{
	assert(consumerID >= 0 && consumerID < _consumers.size());
	
	_consumers[consumerID]->deposit(credit);
}

float Controller::getConsumerCredit(int consumerID) const
{
	assert(consumerID >= 0 && consumerID < _consumers.size());
	
	return _consumers[consumerID]->getCredit();
}

void Controller::addConsumerToSession(int sessionID, int consumerID)
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(consumerID >= 0 && consumerID < _consumers.size());

	_sessions[sessionID]->addConsumer(_consumers[consumerID]);
}

void Controller::removeConsumerFromSession(int sessionID, int consumerID)
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(consumerID >= 0 && consumerID < _consumers.size());

	Session* session = _sessions[sessionID];
	Consumer* consumer = _consumers[consumerID];
	for (int i = 0; i < session->getConsumerCount(); ++i)
	{
		if (session->getConsumerName(i) == consumer->getName())
		{
			session->removeConsumer(i);
			return;
		}
	}
	
	assert(false);
}

bool Controller::isConsumerInSession(int sessionID, int consumerID) const
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(consumerID >= 0 && consumerID < _consumers.size());

	Session* session = _sessions[sessionID];
	Consumer* consumer = _consumers[consumerID];

	for (int i = 0; i < session->getConsumerCount(); ++i)
	{
		if (session->getConsumerName(i) == consumer->getName()) return true;
	}

	return false;
}

void Controller::addItem(int count, const std::string& name, float value, int units)
{
	_inventory.add(count, name, value, units);
}

void Controller::removeItem(int itemID)
{
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	_inventory.removeLowestPrice(getItemName(itemID));
}

int Controller::getItemCount() const
{
	return _inventory.getItemGroupCount();
}

std::string Controller::getItemName(int itemID) const
{
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	return _inventory.getItemGroupName(itemID);
}

int Controller::getItemUnits(int itemID) const
{
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	return _inventory.getItemCount(itemID);
}

void Controller::consumeItem(int sessionID, int itemID)
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	Session* session = _sessions[sessionID];
	session->consumeFrom(&_inventory, getItemName(itemID));
}

void Controller::unconsumeItem(int sessionID, int itemID)
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	Session* session = _sessions[sessionID];
	session->unconsumeTo(&_inventory, getItemName(itemID));
}

int Controller::getSessionItemCount(int sessionID) const
{
	assert(sessionID >= 0 && sessionID < _sessions.size());

	return _sessions[sessionID]->getConsumed()->getItemGroupCount();
}

std::string Controller::getSessionItemName(int sessionID, int itemID) const
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	return _sessions[sessionID]->getConsumed()->getItemGroupName(itemID);
}

int Controller::getSessionItemUnits(int sessionID, int itemID) const
{
	assert(sessionID >= 0 && sessionID < _sessions.size());
	assert(itemID >= 0 && itemID < _inventory.getItemGroupCount());

	return _sessions[sessionID]->getConsumed()->getItemCount(itemID);
}

