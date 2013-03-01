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

int Controller::getSessionCount() const
{
	return _sessions.size();
}

Session* Controller::getSession(int index) const
{
	assert(index >= 0 && index < _sessions.size());
	return _sessions[index];
}
