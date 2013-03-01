#include "gmock/gmock.h"
#include "Controller.h"
#include "Session.h"

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


