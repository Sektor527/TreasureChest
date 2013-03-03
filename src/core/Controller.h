#pragma once
#include <vector>
#include <string>
#include "Inventory.h"

class Session;
class Consumer;

class Controller
{
public:
	void addSession(Session* session);
	void removeSession(int year, int month, int day);
	int getSessionCount() const;
	Session* getSession(int index) const;
	Session* getSession(int year, int month, int day) const;

	void addConsumerToSession(Session* session, Consumer* consumer);
	void removeConsumerFromSession(Session* session, int index);
	int getConsumerCount(const Session* session) const;
	std::string getConsumerName(const Session* session, int index) const;

	void addItemToInventory(int count, const std::string& name, float value, int units = 1);
	int getItemCount() const;
	int getItemGroupCount() const;
	std::string getItemGroupName(int index) const;
	int getItemCount(int index) const;
	int getItemCount(const std::string& name) const;

	void addItemToSession(Session* session, int count, const std::string& name, float price, int units = 1);
	int getItemCount(const Session* session) const;
	int getItemGroupCount(const Session* session) const;
	std::string getItemGroupName(const Session* session, int index) const;
	int getItemCount(const Session* session, int index) const;
	int getItemCount(const Session* session, const std::string& name) const;

private:
	std::vector<Session*> _sessions;
	Inventory _inventory;
};
