#pragma once
#include <vector>

class Session;

class Controller
{
public:
	void addSession(Session* session);
	void removeSession(int year, int month, int day);
	int getSessionCount() const;
	Session* getSession(int index) const;
	Session* getSession(int year, int month, int day) const;

private:
	std::vector<Session*> _sessions;
};
