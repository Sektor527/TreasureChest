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
