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

void Controller::addConsumerToSession(int session, Consumer* consumer)
{
	assert(session >= 0 && session < _sessions.size());

	_sessions[session]->addConsumer(consumer);
}

void Controller::removeConsumerFromSession(int session, int index)
{
	assert(session >= 0 && session < _sessions.size());

	_sessions[session]->removeConsumer(index);
}

int Controller::getConsumerCount(int session) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumerCount();
}

std::string Controller::getConsumerName(int session, int index) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumerName(index);
}

void Controller::addItemToInventory(int count, const std::string& name, float value, int units)
{
	_inventory.add(count, name, value, units);
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

void Controller::addItemToSession(int session, int count, const std::string& name, float price, int units)
{
	assert(session >= 0 && session < _sessions.size());

	_sessions[session]->getConsumed()->add(count, name, price, units);
}

int Controller::getSessionItemCount(int session) const
{
	assert(session >= 0 && session < _sessions.size());

	return _sessions[session]->getConsumed()->getAllCount();
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
