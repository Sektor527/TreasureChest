using System;
using NUnit.Framework;
using TreasureChestCore;

namespace TreasureChestUnitTests
{
	[TestFixture]
	public class SessionTests
	{
		[Test]
		public void AddConsumer()
		{
			Session s = new Session();
			Consumer c = new Consumer("Bart");

			// Normal case
			s.Add(c);
			Assert.AreEqual(1, s.Consumers.Count);
			Assert.Contains(c, s.Consumers);

			// Added twice
			s.Add(c);
			Assert.AreEqual(1, s.Consumers.Count);
			Assert.Contains(c, s.Consumers);
		}

		[Test]
		public void RemoveConsumer()
		{
			Session s = new Session();
			Consumer c1 = new Consumer("Bart");
			Consumer c2 = new Consumer("Jo");

			s.Add(c1);
			
			// Remove non-added consumer
			s.Remove(c2);
			Assert.AreEqual(1, s.Consumers.Count);
			Assert.Contains(c1, s.Consumers);

			// Normal case
			s.Remove(c1);
			Assert.AreEqual(0, s.Consumers.Count);
		}

		[Test]
		public void SessionComparison()
		{
			Session past = new Session(new DateTime(2000, 4, 27));
			Session present_1 = new Session(new DateTime(2010, 6, 17));
			Session present_2 = new Session(new DateTime(2010, 6, 17));
			Session future = new Session(new DateTime(2045, 3, 16));

			Assert.AreEqual(past.CompareTo(past), 0);
			Assert.Less(past.CompareTo(present_1), 0);
			Assert.Less(past.CompareTo(present_2), 0);
			Assert.Less(past.CompareTo(future), 0);

			Assert.Greater(present_1.CompareTo(past), 0);
			Assert.AreEqual(present_1.CompareTo(present_1), 0);
			Assert.AreEqual(present_1.CompareTo(present_2), 0);
			Assert.Less(present_1.CompareTo(future), 0);

			Assert.Greater(present_2.CompareTo(past), 0);
			Assert.AreEqual(present_2.CompareTo(present_1), 0);
			Assert.AreEqual(present_2.CompareTo(present_2), 0);
			Assert.Less(present_2.CompareTo(future), 0);

			Assert.Greater(future.CompareTo(past), 0);
			Assert.Greater(future.CompareTo(present_1), 0);
			Assert.Greater(future.CompareTo(present_2), 0);
			Assert.AreEqual(future.CompareTo(future), 0);
		}

		[Test]
		public void ConsumeFrom()
		{
			Session s = new Session();
			Inventory i = new Inventory();
			i.Add(1, "Hopus", 3f);

			s.ConsumeFrom(i, "Hopus");

			Assert.AreEqual(0, i.Count());
			Assert.AreEqual(1, s.ConsumedItems.Count());
			Assert.AreEqual("Hopus", s.ConsumedItems.Get(0).Name);
		}

		[Test]
		public void UnconsumeTo()
		{
			Session s = new Session();
			Inventory i = new Inventory();
			s.ConsumedItems.Add(1, "Hopus", 3f);

			s.UnconsumeTo(i, "Hopus");

			Assert.AreEqual(0, s.ConsumedItems.Count());
			Assert.AreEqual(1, i.Count());
			Assert.AreEqual("Hopus", i.Get(0).Name);
		}

		[Test]
		public void CreditRedistribution()
		{
			// Setup session
			Session s = new Session();

			// Setup consumers
			Consumer wim = new Consumer("Wim");
			wim.Deposit(10f);
			Consumer bart = new Consumer("Bart");
			bart.Deposit(10f);

			// Setup inventory
			Inventory i = new Inventory();
			i.Add(1, "Hopus", 10f);
			s.ConsumeFrom(i, "Hopus");

			// Add one consumer
			s.Add(wim);
			Assert.AreEqual(0f, wim.Credit);
			Assert.AreEqual(10f, bart.Credit);

			// Add a second consumer
			s.Add(bart);
			Assert.AreEqual(5f, wim.Credit);
			Assert.AreEqual(5f, bart.Credit);

			// Remove a consumer
			s.Remove(wim);
			Assert.AreEqual(10f, wim.Credit);
			Assert.AreEqual(0f, bart.Credit);


		}
	}
}
