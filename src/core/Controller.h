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
	int getSession(int year, int month, int day) const;

	void addConsumer(const std::string& name);
	int getConsumerCount() const;
	void removeConsumer(int consumer);
	std::string getConsumerName(int consumer) const;
	int getConsumer(const std::string& name) const;
	void depositCredit(int consumer, float credit);
	float getConsumerCredit(int consumer) const;

	void addConsumerToSession(int session, int consumer);
	void removeConsumerFromSession(int session, int index);
	bool isConsumerInSession(int session, int consumer) const;

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
	std::vector<Consumer*> _consumers;
	Inventory _inventory;
};
