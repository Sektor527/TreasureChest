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

TEST(ControllerConsumerTests, GetConsumer)
{
	Controller c;
	c.addConsumer("wim");

	ASSERT_EQ(0, c.getConsumer("wim"));
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
		c.addItemToInventory(3, "item 1", 5.f);
		c.addItemToInventory(2, "item 2", 4.f);
		c.addItemToInventory(1, "item 3", 3.f, 3);
	}
	
	Controller c;
};

TEST_F(ControllerInventoryTests, GetItemCount)
{
	ASSERT_EQ(8, c.getItemCount());
}

TEST_F(ControllerInventoryTests, GetItemGroupCount)
{
	ASSERT_EQ(3, c.getItemGroupCount());
}

TEST_F(ControllerInventoryTests, GetItemGroupName)
{
	ASSERT_EQ("item 1", c.getItemGroupName(0));
	ASSERT_EQ("item 2", c.getItemGroupName(1));
	ASSERT_EQ("item 3", c.getItemGroupName(2));
}

TEST_F(ControllerInventoryTests, GetItemCountsFromInventoryByName)
{
	ASSERT_EQ(3, c.getItemCount("item 1"));
	ASSERT_EQ(2, c.getItemCount("item 2"));
	ASSERT_EQ(3, c.getItemCount("item 3"));
}

TEST_F(ControllerInventoryTests, GetItemCountsFromInventoryByIndex)
{
	ASSERT_EQ(3, c.getItemCount(0));
	ASSERT_EQ(2, c.getItemCount(1));
	ASSERT_EQ(3, c.getItemCount(2));
}

class ControllerSessionInventoryTests : public ::testing::Test
{
public:
	virtual void SetUp()
	{
		c.addSession(2000, 1, 1);

		c.addItemToSession(0, 3, "item 1", 5.f);
		c.addItemToSession(0, 2, "item 2", 4.f);
		c.addItemToSession(0, 1, "item 3", 3.f, 3);
	}
	
	Controller c;
};

TEST_F(ControllerSessionInventoryTests, GetItemCount)
{
	ASSERT_EQ(8, c.getSessionItemCount(0));
}

TEST_F(ControllerSessionInventoryTests, GetItemGroupCount)
{
	ASSERT_EQ(3, c.getSessionItemGroupCount(0));
}

TEST_F(ControllerSessionInventoryTests, GetItemGroupName)
{
	ASSERT_EQ("item 1", c.getSessionItemGroupName(0, 0));
	ASSERT_EQ("item 2", c.getSessionItemGroupName(0, 1));
	ASSERT_EQ("item 3", c.getSessionItemGroupName(0, 2));
}

TEST_F(ControllerSessionInventoryTests, GetItemCountsFromInventoryByName)
{
	ASSERT_EQ(3, c.getSessionItemCount(0, "item 1"));
	ASSERT_EQ(2, c.getSessionItemCount(0, "item 2"));
	ASSERT_EQ(3, c.getSessionItemCount(0, "item 3"));
}

TEST_F(ControllerSessionInventoryTests, GetItemCountsFromInventoryByIndex)
{
	ASSERT_EQ(3, c.getSessionItemCount(0, 0));
	ASSERT_EQ(2, c.getSessionItemCount(0, 1));
	ASSERT_EQ(3, c.getSessionItemCount(0, 2));
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
