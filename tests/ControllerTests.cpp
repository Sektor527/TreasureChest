#include "gmock/gmock.h"
#include "Controller.h"
#include "Session.h"
#include "Consumer.h"

TEST(ControllerSessionTests, AddSession)
{
	Controller c;
	c.addSession(2000, 1, 1);
	
	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, SessionsSortedOnYear)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addSession(1998, 1, 1);

	ASSERT_EQ(0, c.getSession(1998, 1, 1));
	ASSERT_EQ(1, c.getSession(2000, 1, 1));
}

TEST(ControllerSessionTests, SessionsSortedOnMonth)
{
	Controller c;
	c.addSession(2000, 6, 1);
	c.addSession(2000, 5, 1);

	ASSERT_EQ(0, c.getSession(2000, 5, 1));
	ASSERT_EQ(1, c.getSession(2000, 6, 1));
}

TEST(ControllerSessionTests, SessionsSortedOnDay)
{
	Controller c;
	c.addSession(2000, 1, 27);
	c.addSession(2000, 1, 18);

	ASSERT_EQ(0, c.getSession(2000, 1, 18));
	ASSERT_EQ(1, c.getSession(2000, 1, 27));
}

TEST(ControllerSessionTests, GetSessionOnDate)
{
	Controller c;
	c.addSession(1979, 4, 27);

	ASSERT_EQ(0, c.getSession(1979, 4, 27));
}

TEST(ControllerSessionTests, RemoveSession)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addSession(1998, 1, 1);

	c.removeSession(1);

	ASSERT_EQ(1, c.getSessionCount());
	ASSERT_EQ(0, c.getSession(1998, 1, 1));
}

TEST(ControllerConsumerTests, AddConsumer)
{
	Controller c;
	c.addConsumer("wim");

	ASSERT_EQ(1, c.getConsumerCount());
}

TEST(ControllerConsumerTests, RemoveConsumer)
{
	Controller c;
	c.addConsumer("wim");

	c.removeConsumer(0);

	ASSERT_EQ(0, c.getConsumerCount());
}

TEST(ControllerConsumerTests, GetConsumerName)
{
	Controller c;
	c.addConsumer("Wim");

	ASSERT_EQ("Wim", c.getConsumerName(0));
}

TEST(ControllerConsumerTests, DepositCredits)
{
	Controller c;
	c.addConsumer("Wim");

	c.depositCredit(0, 10.f);
	ASSERT_EQ(10.f, c.getConsumerCredit(0));
}

class ControllerInventoryTests : public ::testing::Test
{
public:
	virtual void SetUp()
	{
		c.addItem(3, "item 1", 5.f);
		c.addItem(2, "item 2", 4.f);
		c.addItem(1, "item 3", 3.f, 3);
	}
	
	Controller c;
};

TEST_F(ControllerInventoryTests, GetItemCount)
{
	ASSERT_EQ(3, c.getItemCount());
}

TEST_F(ControllerInventoryTests, GetItemName)
{
	ASSERT_EQ("item 1", c.getItemName(0));
	ASSERT_EQ("item 2", c.getItemName(1));
	ASSERT_EQ("item 3", c.getItemName(2));
}

TEST_F(ControllerInventoryTests, GetItemCountsFromInventoryByIndex)
{
	ASSERT_EQ(3, c.getItemUnits(0));
	ASSERT_EQ(2, c.getItemUnits(1));
	ASSERT_EQ(3, c.getItemUnits(2));
}

TEST_F(ControllerInventoryTests, RemoveItemFromInventory)
{
	c.removeItem(0);

	ASSERT_EQ(2, c.getItemUnits(0));
}

TEST(ControllerSessionInventoryTests, ConsumeItemGroupCount)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addItem(3, "item 1", 5.f);
	c.addItem(1, "item 2", 3.f);
	c.consumeItem(0, 0);
	c.consumeItem(0, 1);

	ASSERT_EQ(2, c.getSessionItemCount(0));
	ASSERT_EQ(1, c.getItemCount());
}

TEST(ControllerSessionInventoryTests, ConsumeItemGroupName)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addItem(3, "item 1", 5.f);
	c.consumeItem(0, 0);

	ASSERT_EQ("item 1", c.getSessionItemName(0, 0));
}

TEST(ControllerSessionInventoryTests, ConsumeItemCount)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addItem(3, "item 1", 5.f);
	c.consumeItem(0, 0);
	c.consumeItem(0, 0);

	ASSERT_EQ(2, c.getSessionItemUnits(0, 0));
	ASSERT_EQ(1, c.getItemUnits(0));
}

class ControllerSessionConsumerTests : public ::testing::Test
{
public:
	virtual void SetUp()
	{
		c.addSession(2000, 1, 1);
		c.addConsumer("a");
		c.addConsumer("b");
		c.addConsumerToSession(0, 1);
	}

	Controller c;
};

TEST_F(ControllerSessionConsumerTests, ConsumerInSession)
{
	ASSERT_FALSE(c.isConsumerInSession(0, 0));
	ASSERT_TRUE(c.isConsumerInSession(0, 1));
}

TEST_F(ControllerSessionConsumerTests, RemoveConsumersFromSession)
{
	c.removeConsumerFromSession(0, 1);

	ASSERT_FALSE(c.isConsumerInSession(0, 1));
}
