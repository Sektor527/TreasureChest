using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TreasureChestCore;

namespace TreasureChestUnitTests
{
	[TestFixture]
	public class ConsumerTests
	{
		[Test]
		public void Credit()
		{
			Consumer c = new Consumer("Consumer");

			Assert.AreEqual(0, c.Credit);
		}

		[Test]
		public void CreditDeposit()
		{
			Consumer c = new Consumer("Consumer");

			c.Deposit(100);
			Assert.AreEqual(100, c.Credit);

			c.Deposit(50);
			Assert.AreEqual(150, c.Credit);
		}

		[Test]
		public void CreditWithdraw()
		{
			Consumer c = new Consumer("Consumer");
			c.Deposit(100);

			c.Withdraw(75);
			Assert.AreEqual(25, c.Credit);

			c.Withdraw(50);
			Assert.AreEqual(-25, c.Credit);
		}
	}
}
