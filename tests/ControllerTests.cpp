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

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, SessionsSortedOnMonth)
{
	Controller c;
	c.addSession(2000, 6, 1);
	c.addSession(2000, 5, 1);

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, SessionsSortedOnDay)
{
	Controller c;
	c.addSession(2000, 1, 27);
	c.addSession(2000, 1, 18);

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, GetSessionOnDate)
{
	Controller c;
	c.addSession(1979, 4, 27);

	ASSERT_TRUE(NULL != c.getSession(1979, 4, 27));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingEarlierDate)
{
	Controller c;
	c.addSession(1979, 4, 27);

	ASSERT_EQ(NULL, c.getSession(1979, 4, 26));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingLaterDate)
{
	Controller c;
	c.addSession(1979, 4, 27);

	ASSERT_EQ(NULL, c.getSession(2000, 4, 27));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingInBetweenDate)
{
	Controller c;
	c.addSession(1979, 4, 27);
	c.addSession(2013, 3, 1);

	ASSERT_EQ(NULL, c.getSession(2000, 4, 27));
}

TEST(ControllerSessionTests, RemoveSession)
{
	Controller c;
	c.addSession(2000, 1, 1);
	c.addSession(1998, 1, 1);

	c.removeSession(2000, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
	ASSERT_EQ(NULL, c.getSession(2000, 1, 1));
}

TEST(ControllerSessionTests, RemoveNonExistingEarlierSession)
{
	Controller c;
	c.addSession(1998, 1, 1);

	c.removeSession(1980, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, RemoveNonExistingLaterSession)
{
	Controller c;
	c.addSession(1998, 1, 1);

	c.removeSession(2000, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, RemoveNonExistingInBetweenSession)
{
	Controller c;
	c.addSession(1998, 1, 1);
	c.addSession(2013, 1, 1);

	c.removeSession(2000, 1, 1);

	ASSERT_EQ(2, c.getSessionCount());
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

class ControllerConsumerTests : public ::testing::Test
{
public:
	ControllerConsumerTests() : a("wim") {}

	virtual void SetUp()
	{
		c.addSession(2000, 1, 1);
		c.addConsumerToSession(0, &a);
	}

	Controller c;
	Consumer a;
};

TEST_F(ControllerConsumerTests, AddConsumersToSession)
{
	ASSERT_EQ(1, c.getConsumerCount(0));
}

TEST_F(ControllerConsumerTests, GetConsumerName)
{
	ASSERT_EQ("wim", c.getConsumerName(0, 0));
}

TEST_F(ControllerConsumerTests, RemoveConsumersFromSession)
{
	c.removeConsumerFromSession(0, 0);

	ASSERT_EQ(0, c.getConsumerCount(0));
}