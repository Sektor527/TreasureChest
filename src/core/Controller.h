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
	void removeSession(int sessionID);
	int getSessionCount() const;
	int getSession(int year, int month, int day) const;

	void addConsumer(const std::string& name);
	void removeConsumer(int consumerID);
	void depositCredit(int consumerID, float credit);
	int getConsumerCount() const;
	std::string getConsumerName(int consumerID) const;
	float getConsumerCredit(int consumerID) const;

	void addConsumerToSession(int sessionID, int consumerID);
	void removeConsumerFromSession(int sessionID, int consumerID);
	bool isConsumerInSession(int sessionID, int consumerID) const;

	void addItem(int count, const std::string& name, float value, int units = 1);
	void removeItem(int itemID);
	int getItemCount() const;
	std::string getItemName(int itemID) const;
	int getItemUnits(int itemID) const;

	void consumeItem(int sessionID, int itemID);
	void unconsumeItem(int sessionID, int itemID);
	int getSessionItemCount(int sessionID) const;
	std::string getSessionItemName(int sessionID, int itemID) const;
	int getSessionItemUnits(int sessionID, int itemID) const;

private:
	std::vector<Session*> _sessions;
	std::vector<Consumer*> _consumers;
	Inventory _inventory;
};
