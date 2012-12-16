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
	void removeConsumer(Consumer* consumer);

	int getConsumerCount() const;
	std::string getConsumerName(int index) const;

	// Date
	bool isBefore(const Session* other) const;
	bool isAfter(const Session* other) const;

	// Consumed items
	void consumeFrom(Inventory* inventory, const std::string& item);
	void unconsumeTo(Inventory* inventory, const std::string& item);
	int getConsumedCount() const;

private:
	typedef std::vector<Consumer*> consumers_t;
	consumers_t m_consumers;

	time_t m_time;

	Inventory* m_consumed;
};
