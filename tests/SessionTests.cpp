#include "gmock/gmock.h"
#include "Session.h"
#include "Consumer.h"
#include "Inventory.h"

TEST(SessionTests, GetConsumerCount)
{
	Session s;
	Consumer c("Bart");

	s.addConsumer(&c);
	ASSERT_EQ(1, s.getConsumerCount());
}

TEST(SessionTests, GetConsumerName)
{
	Session s;
	Consumer c("Bart");

	s.addConsumer(&c);

	ASSERT_EQ("Bart", s.getConsumerName(0));
}

TEST(SessionTests, RemoveConsumer)
{
	Session s;

	s.addConsumer(new Consumer("Bart"));
	s.removeConsumer(0);

	ASSERT_EQ(0, s.getConsumerCount());
}

TEST(SessionTests, SessionTimeBefore)
{
	Session past(2012, 4, 27);
	Session future(2025, 3, 16);

	ASSERT_TRUE(past.isBefore(&future));
}

TEST(SessionTests, SessionTimeNotBefore)
{
	Session past(2012, 4, 27);
	Session future(2025, 3, 16);

	ASSERT_FALSE(future.isBefore(&past));
}

TEST(SessionTests, SessionTimeAfter)
{
	Session past(2012, 4, 27);
	Session future(2025, 3, 16);

	ASSERT_TRUE(future.isAfter(&past));
}

TEST(SessionTests, SessionTimeNotAfter)
{
	Session past(2012, 4, 27);
	Session future(2025, 3, 16);

	ASSERT_FALSE(past.isAfter(&future));
}

TEST(SessionTests, ConsumeFrom)
{
	Session s;
	Inventory i;
	i.add(1, "Chips", 3.0f);

	s.consumeFrom(&i, "Chips");

	ASSERT_EQ(0, i.getAllCount());
	ASSERT_EQ(1, s.getConsumedCount());
}

TEST(SessionTests, UnconsumeTo)
{
	Session s;
	Inventory i;
	i.add(1, "Chips", 3.0f);

	s.consumeFrom(&i, "Chips");
	s.unconsumeTo(&i, "Chips");

	ASSERT_EQ(1, i.getAllCount());
	ASSERT_EQ(0, s.getConsumedCount());
}

TEST(SessionTests, CreditRedistributionAddOneConsumer)
{
	Session s;
	Consumer c1("Wim");
	Consumer c2("Bart");
	c1.deposit(10.f);
	c2.deposit(10.f);

	Inventory i;
	i.add(1, "Chips", 10.f);
	s.consumeFrom(&i, "Chips");

	s.addConsumer(&c1);
	ASSERT_EQ(0.f, c1.getCredit());
	ASSERT_EQ(10.f, c2.getCredit());
}

TEST(SessionTests, CreditRedistributionAddTwoConsumers)
{
	Session s;
	Consumer c1("Wim");
	Consumer c2("Bart");
	c1.deposit(10.f);
	c2.deposit(10.f);

	Inventory i;
	i.add(1, "Chips", 10.f);
	s.consumeFrom(&i, "Chips");

	s.addConsumer(&c1);
	s.addConsumer(&c2);
	ASSERT_EQ(5.f, c1.getCredit());
	ASSERT_EQ(5.f, c2.getCredit());
}

TEST(SessionTests, CreditRedistributionRemoveConsumer)
{
	Session s;
	Consumer c1("Wim");
	Consumer c2("Bart");
	c1.deposit(10.f);
	c2.deposit(10.f);

	Inventory i;
	i.add(1, "Chips", 10.f);
	s.consumeFrom(&i, "Chips");

	s.addConsumer(&c1);
	s.addConsumer(&c2);

	s.removeConsumer(0);
	ASSERT_EQ(10.f, c1.getCredit());
	ASSERT_EQ(0.f, c2.getCredit());
}
