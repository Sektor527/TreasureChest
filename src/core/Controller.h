#pragma once
#include <vector>

class Session;

class Controller
{
public:
	void addSession(Session* session);
	int getSessionCount() const;
	Session* getSession(int index) const;

private:
	std::vector<Session*> _sessions;
};
