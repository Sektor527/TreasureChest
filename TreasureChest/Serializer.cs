using System;
using System.Collections.Generic;

namespace TreasureChest
{
	static class Serializer
	{
		internal static void Serialize(List<Session> sessions, Inventory inventory)
		{
			SerializeConsumers();
			SerializeSessions(sessions);
			SerializeInventory(inventory);
		}

		private static void SerializeConsumers()
		{
			throw new NotImplementedException();
		}

		private static void SerializeSessions(List<Session> sessions)
		{
			throw new NotImplementedException();
		}

		private static void SerializeInventory(Inventory inventory)
		{
			throw new NotImplementedException();
		}

		internal static void Deserialize(List<Session> sessions, Inventory inventory)
		{
			DeserializeConsumers();
			DeserializeSessions(sessions);
			DeserializeInventory(inventory);
		}

		private static void DeserializeConsumers()
		{
			throw new NotImplementedException();
		}

		private static void DeserializeSessions(List<Session> sessions)
		{
			throw new NotImplementedException();
		}

		private static void DeserializeInventory(Inventory inventory)
		{
			throw new NotImplementedException();
		}
	}
}
