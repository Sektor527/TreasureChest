#include "gmock/gmock.h"
#include "Controller.h"
#include "Session.h"
#include "Consumer.h"

TEST(ControllerSessionTests, AddSession)
{
	Controller c;
	c.addSession(new Session());
	
	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, SessionsSortedOnYear)
{
	Controller c;
	c.addSession(new Session(2000, 1, 1));
	c.addSession(new Session(1998, 1, 1));

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, SessionsSortedOnMonth)
{
	Controller c;
	c.addSession(new Session(2000, 6, 1));
	c.addSession(new Session(2000, 5, 1));

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, SessionsSortedOnDay)
{
	Controller c;
	c.addSession(new Session(2000, 1, 27));
	c.addSession(new Session(2000, 1, 18));

	ASSERT_TRUE(c.getSession(0)->isBefore(c.getSession(1)));
}

TEST(ControllerSessionTests, GetSessionOnDate)
{
	Controller c;
	Session* session = new Session(1979, 4, 27);
	c.addSession(session);

	ASSERT_EQ(session, c.getSession(1979, 4, 27));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingEarlierDate)
{
	Controller c;
	c.addSession(new Session(1979, 4, 27));

	ASSERT_EQ(NULL, c.getSession(1979, 4, 26));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingLaterDate)
{
	Controller c;
	c.addSession(new Session(1979, 4, 27));

	ASSERT_EQ(NULL, c.getSession(2000, 4, 27));
}

TEST(ControllerSessionTests, GetSessionOnNonExistingInBetweenDate)
{
	Controller c;
	c.addSession(new Session(1979, 4, 27));
	c.addSession(new Session(2013, 3, 1));

	ASSERT_EQ(NULL, c.getSession(2000, 4, 27));
}

TEST(ControllerSessionTests, RemoveSession)
{
	Controller c;
	c.addSession(new Session(2000, 1, 1));
	c.addSession(new Session(1998, 1, 1));

	c.removeSession(2000, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
	ASSERT_EQ(NULL, c.getSession(2000, 1, 1));
}

TEST(ControllerSessionTests, RemoveNonExistingEarlierSession)
{
	Controller c;
	c.addSession(new Session(1998, 1, 1));

	c.removeSession(1980, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, RemoveNonExistingLaterSession)
{
	Controller c;
	c.addSession(new Session(1998, 1, 1));

	c.removeSession(2000, 1, 1);

	ASSERT_EQ(1, c.getSessionCount());
}

TEST(ControllerSessionTests, RemoveNonExistingInBetweenSession)
{
	Controller c;
	c.addSession(new Session(1998, 1, 1));
	c.addSession(new Session(2013, 1, 1));

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
		c.addSession(&s);

		c.addItemToSession(&s, 3, "item 1", 5.f);
		c.addItemToSession(&s, 2, "item 2", 4.f);
		c.addItemToSession(&s, 1, "item 3", 3.f, 3);
	}
	
	Controller c;
	Session s;
};

TEST_F(ControllerSessionInventoryTests, GetItemCount)
{
	ASSERT_EQ(8, c.getItemCount(&s));
}

TEST_F(ControllerSessionInventoryTests, GetItemGroupCount)
{
	ASSERT_EQ(3, c.getItemGroupCount(&s));
}

TEST_F(ControllerSessionInventoryTests, GetItemGroupName)
{
	ASSERT_EQ("item 1", c.getItemGroupName(&s, 0));
	ASSERT_EQ("item 2", c.getItemGroupName(&s, 1));
	ASSERT_EQ("item 3", c.getItemGroupName(&s, 2));
}

TEST_F(ControllerSessionInventoryTests, GetItemCountsFromInventoryByName)
{
	ASSERT_EQ(3, c.getItemCount(&s, "item 1"));
	ASSERT_EQ(2, c.getItemCount(&s, "item 2"));
	ASSERT_EQ(3, c.getItemCount(&s, "item 3"));
}

TEST_F(ControllerSessionInventoryTests, GetItemCountsFromInventoryByIndex)
{
	ASSERT_EQ(3, c.getItemCount(&s, 0));
	ASSERT_EQ(2, c.getItemCount(&s, 1));
	ASSERT_EQ(3, c.getItemCount(&s, 2));
}

class ControllerConsumerTests : public ::testing::Test
{
public:
	ControllerConsumerTests() : a("wim") {}

	virtual void SetUp()
	{
		c.addSession(&s);
		c.addConsumerToSession(&s, &a);
	}

	Controller c;
	Session s;
	Consumer a;
};

TEST_F(ControllerConsumerTests, AddConsumersToSession)
{
	ASSERT_EQ(1, c.getConsumerCount(&s));
}

TEST_F(ControllerConsumerTests, GetConsumerName)
{
	ASSERT_EQ("wim", c.getConsumerName(&s, 0));
}

TEST_F(ControllerConsumerTests, RemoveConsumersFromSession)
{
	c.removeConsumerFromSession(&s, 0);

	ASSERT_EQ(0, c.getConsumerCount(&s));
}
