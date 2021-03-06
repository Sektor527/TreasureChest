#pragma once
#include <string>
#include <vector>

class Consumer;
class Inventory;

class Session
{
public:
	Session();
	Session(int year, int month, int day);

	~Session();

	// Consumers
	void addConsumer(Consumer* consumer);
	void removeConsumer(int index);

	int getConsumerCount() const;
	std::string getConsumerName(int index) const;

	// Date
	bool isEqual(const Session* other) const;
	bool isBefore(const Session* other) const;
	bool isAfter(const Session* other) const;

	// Consumed items
	void consumeFrom(Inventory* inventory, const std::string& item);
	void unconsumeTo(Inventory* inventory, const std::string& item);
	int getConsumedCount() const;

	Inventory* getConsumed() const;

private:
	typedef std::vector<Consumer*> consumers_t;
	consumers_t m_consumers;

	time_t m_time;

	Inventory* m_consumed;
};
