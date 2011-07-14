using NUnit.Framework;
using TreasureChest;

namespace TreasureChestUnitTests
{
	[TestFixture]
	public class ConsumerTests
	{
		[Test]
		public void ConsumerInSession()
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
	}
}
