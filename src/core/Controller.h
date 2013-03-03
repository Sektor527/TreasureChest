#pragma once
#include <vector>
#include <string>
#include "Inventory.h"

class Session;
class Consumer;

class Controller
{
public:
	void addSession(int year, int month, int day);
	int getSessionCount() const;
	void removeSession(int session);
	Session* getSession(int index) const;
	Session* getSession(int year, int month, int day) const;

	void addConsumerToSession(int session, Consumer* consumer);
	void removeConsumerFromSession(int session, int index);
	int getConsumerCount(int session) const;
	std::string getConsumerName(int session, int index) const;

	void addItemToInventory(int count, const std::string& name, float value, int units = 1);
	int getItemCount() const;
	int getItemGroupCount() const;
	std::string getItemGroupName(int index) const;
	int getItemCount(int index) const;
	int getItemCount(const std::string& name) const;

	void addItemToSession(int session, int count, const std::string& name, float price, int units = 1);
	int getSessionItemCount(int session) const;
	int getSessionItemGroupCount(int session) const;
	std::string getSessionItemGroupName(int session, int index) const;
	int getSessionItemCount(int session, int index) const;
	int getSessionItemCount(int session, const std::string& name) const;

private:
	std::vector<Session*> _sessions;
	Inventory _inventory;
};
