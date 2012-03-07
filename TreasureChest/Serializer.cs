using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace TreasureChest
{
	static class Serializer
	{
		private static XmlDocument _document;

		internal static void Serialize(List<Session> sessions, List<Consumer> consumers, Inventory inventory)
		{
			_document = new XmlDocument();
			_document.AppendChild(_document.CreateXmlDeclaration("1.0", null, null));
			XmlNode root = _document.AppendChild(_document.CreateElement("TreasureChest"));

			SerializeConsumers(root, consumers);
			SerializeSessions(root, sessions);
			SerializeInventory(root, inventory);

			_document.Save("chest.dat");
		}

		private static void SerializeConsumers(XmlNode root, List<Consumer> consumers)
		{
			XmlNode nodeConsumers = root.AppendChild(_document.CreateElement("Consumers"));

			foreach (Consumer c in consumers)
			{
				XmlElement node = (XmlElement) nodeConsumers.AppendChild(_document.CreateElement("Consumer"));
				node.SetAttribute("Name", c.Name);
				node.SetAttribute("Credit", c.Credit.ToString(CultureInfo.InvariantCulture));
			}
		}

		private static void SerializeSessions(XmlNode root, List<Session> sessions)
		{
			XmlNode nodeSessions = root.AppendChild(_document.CreateElement("Sessions"));

			foreach (Session session in sessions)
			{
				// Date
				XmlElement nodeSession = (XmlElement)nodeSessions.AppendChild(_document.CreateElement("Session"));
				nodeSession.SetAttribute("Date", session.Date.ToString(CultureInfo.InvariantCulture));

				// List of attendants
				XmlElement nodeAttendants = (XmlElement)nodeSession.AppendChild(_document.CreateElement("Attendants"));
				foreach (Consumer consumer in session.Consumers)
					nodeAttendants.AppendChild(_document.CreateElement(consumer.Name));

				// List of consumed items
				XmlElement nodeConsumed = (XmlElement)nodeSession.AppendChild(_document.CreateElement("ConsumedItems"));
				for (int i = 0; i < session.ConsumedItems.Count(); ++i)
				{
					Item item = session.ConsumedItems.Get(i);
					XmlElement nodeItem = (XmlElement)nodeConsumed.AppendChild(_document.CreateElement("ConsumedItem"));
					nodeItem.SetAttribute("Name", item.Name);
					nodeItem.SetAttribute("Price", item.UnitPrice.ToString(CultureInfo.InvariantCulture));
				}
			}
		}

		private static void SerializeInventory(XmlNode root, Inventory inventory)
		{
			XmlNode nodeInventory = root.AppendChild(_document.CreateElement("Inventory"));

			for (int i = 0; i < inventory.Count(); ++i)
			{
				Item item = inventory.Get(i);
				XmlElement nodeItem = (XmlElement)nodeInventory.AppendChild(_document.CreateElement("Item"));
				nodeItem.SetAttribute("Name", item.Name);
				nodeItem.SetAttribute("Price", item.UnitPrice.ToString(CultureInfo.InvariantCulture));
			}
		}

		internal static void Deserialize(List<Session> sessions, List<Consumer> consumers, Inventory inventory)
		{
			if (!File.Exists("chest.dat")) return;

			XmlDocument document = new XmlDocument();
			document.Load("chest.dat");

			DeserializeConsumers(document, consumers);
			DeserializeSessions(document, sessions);
			DeserializeInventory(document, inventory);
		}

		private static void DeserializeConsumers(XmlDocument document, List<Consumer> consumers)
		{
			foreach (XmlNode nodeConsumer in document.GetElementsByTagName("Consumer"))
			{
				string name = nodeConsumer.Attributes["Name"].Value;
				Consumer consumer = new Consumer(name);

				consumer.Credit = float.Parse(nodeConsumer.Attributes["Credit"].Value, CultureInfo.InvariantCulture);
				consumers.Add(consumer);
			}
		}

		private static void DeserializeSessions(XmlDocument document, List<Session> sessions)
		{
			foreach (XmlNode nodeSession in document.GetElementsByTagName("Session"))
			{
				DateTime date = DateTime.Parse(nodeSession.Attributes["Date"].Value, CultureInfo.InvariantCulture);
				Session session = new Session(date);
				sessions.Add(session);

				foreach (XmlNode nodeAttendant in nodeSession.ChildNodes[0].ChildNodes)
				{
					switch (nodeAttendant.Name)
					{
						case "Wim":
							session.Consumers.Add(Consumer.Wim);
							break;
						case "Bart":
							session.Consumers.Add(Consumer.Bart);
							break;
						case "Jo":
							session.Consumers.Add(Consumer.Jo);
							break;
						case "Koen":
							session.Consumers.Add(Consumer.Koen);
							break;
						case "Frederik":
							session.Consumers.Add(Consumer.Frederik);
							break;
						case "Christoph":
							session.Consumers.Add(Consumer.Christoph);
							break;
						case "Christof":
							session.Consumers.Add(Consumer.Christof);
							break;
					}
				}

				foreach (XmlNode nodeConsumed in nodeSession.ChildNodes[1].ChildNodes)
				{
					session.ConsumedItems.Add(new Item
					{
						Name = nodeConsumed.Attributes["Name"].Value,
						UnitPrice = float.Parse(nodeConsumed.Attributes["Price"].Value, CultureInfo.InvariantCulture)
					});
				}
			}
		}

		private static void DeserializeInventory(XmlDocument document, Inventory inventory)
		{
			foreach (XmlNode nodeItem in document.GetElementsByTagName("Item"))
			{
				inventory.Add(new Item { Name = nodeItem.Attributes["Name"].Value, UnitPrice = float.Parse(nodeItem.Attributes["Price"].Value, CultureInfo.InvariantCulture) });
			}
		}
	}
}
