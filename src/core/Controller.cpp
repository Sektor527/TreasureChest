#include "Controller.h"
#include "Session.h"
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
