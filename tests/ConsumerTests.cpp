#include "gmock/gmock.h"
#include "Consumer.h"

TEST(ConsumerTests, Name)
{
	Consumer c("Abc");
	ASSERT_EQ("Abc", c.getName());
}

TEST(ConsumerTests, InitialCredit)
{
	Consumer c("Abc");
	ASSERT_EQ(0, c.getCredit());
}

TEST(ConsumerTests, Deposit)
{
	Consumer c("Abc");
	c.deposit(100);
	ASSERT_EQ(100, c.getCredit());
}

TEST(ConsumerTests, AccumulatedDeposit)
{
	Consumer c("Abc");
	c.deposit(100);
	c.deposit(50);
	ASSERT_EQ(150, c.getCredit());
}

TEST(ConsumerTests, Withdraw)
{
	Consumer c("Abc");
	c.withdraw(50);
	ASSERT_EQ(-50, c.getCredit());
}

TEST(ConsumerTests, AccumulatedWithdraw)
{
	Consumer c("Abc");
	c.withdraw(50);
	c.withdraw(40);
	ASSERT_EQ(-90, c.getCredit());
}

TEST(ConsumerTests, DepositAndWithdraw)
{
	Consumer c("Abc");
	c.deposit(100);
	c.withdraw(70);
	ASSERT_EQ(30, c.getCredit());
}
