#include "Controller.h"
#include "Session.h"
#include "Consumer.h"
#include <cassert>

void Controller::addSession(Session* session)
{
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

void Controller::removeSession(int year, int month, int day)
{
	Session target(year, month, day);

	std::vector<Session*>::iterator it;
	for (it = _sessions.begin(); it != _sessions.end(); ++it)
	{
		Session* session = *it;
		if (session->isAfter(&target)) return;
		if (session->isBefore(&target)) continue;

		_sessions.erase(it);
		break;
	}
}

int Controller::getSessionCount() const
{
	return _sessions.size();
}

Session* Controller::getSession(int index) const
{
	assert(index >= 0 && index < _sessions.size());
	return _sessions[index];
}

Session* Controller::getSession(int year, int month, int day) const
{
	Session target(year, month, day);

	std::vector<Session*>::const_iterator it;
	for (it = _sessions.begin(); it != _sessions.end(); ++it)
	{
		Session* session = *it;
		if (session->isAfter(&target)) return NULL;
		if (session->isBefore(&target)) continue;

		return *it;
	}
	
	return NULL;
}

void Controller::addConsumerToSession(Session* session, Consumer* consumer)
{
	session->addConsumer(consumer);
}

void Controller::removeConsumerFromSession(Session* session, int index)
{
	session->removeConsumer(index);
}

int Controller::getConsumerCount(const Session* session) const
{
	return session->getConsumerCount();
}

std::string Controller::getConsumerName(const Session* session, int index) const
{
	return session->getConsumerName(index);
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

void Controller::addItemToSession(Session* session, int count, const std::string& name, float price, int units)
{
	session->getConsumed()->add(count, name, price, units);
}

int Controller::getItemCount(const Session* session) const
{
	return session->getConsumed()->getAllCount();
}

int Controller::getItemGroupCount(const Session* session) const
{
	return session->getConsumed()->getItemGroupCount();
}

std::string Controller::getItemGroupName(const Session* session, int index) const
{
	return session->getConsumed()->getItemGroupName(index);
}

int Controller::getItemCount(const Session* session, int index) const
{
	return session->getConsumed()->getItemCount(index);
}

int Controller::getItemCount(const Session* session, const std::string& name) const
{
	return session->getConsumed()->getItemCount(name);
}
