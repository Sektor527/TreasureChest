using NUnit.Framework;
using TreasureChest;

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
	}
}
