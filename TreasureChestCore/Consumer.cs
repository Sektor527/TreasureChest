﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChestCore
{
	public class Consumer
	{
		public string Name { get; set; }
		public float Credit { get; set; }

		public Consumer(string name)
		{
			Name = name;
		}

		internal void Deposit(float amount)
		{
			Credit += amount;
		}

		internal void Withdraw(float amount)
		{
			Credit -= amount;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object obj)
		{
			return GetHashCode() == obj.GetHashCode();
		}

		public static readonly Consumer Wim = new Consumer("Wim");
		public static readonly Consumer Frederik = new Consumer("Frederik");
		public static readonly Consumer Jo = new Consumer("Jo");
		public static readonly Consumer Koen = new Consumer("Koen");
		public static readonly Consumer Christof = new Consumer("Christof");
		public static readonly Consumer Christoph = new Consumer("Christoph");
		public static readonly Consumer Bart = new Consumer("Bart");
	}
}
