#include "gmock/gmock.h"
#include "Inventory.h"

TEST(InventoryTests, CountSingleItem)
{
	Inventory i;
	i.add(1, "Chips", 3.20f);

	ASSERT_EQ(1, i.getAllCount());
}

TEST(InventoryTests, CountMultipleSingleItems)
{
	Inventory i;
	i.add(3, "Chips", 3.20f);

	ASSERT_EQ(3, i.getAllCount());
}

TEST(InventoryTests, GetSingleItemName)
{
	Inventory i;
	i.add(1, "Chips", 3.20f);

	ASSERT_EQ("Chips", i.getItemName(0));
}

TEST(InventoryTests, GetSingleItemUnitPrice)
{
	Inventory i;
	i.add(1, "Chips", 3.20f);

	ASSERT_EQ(3.20f, i.getItemPrice(0));
}

TEST(InventoryTests, CountGroupedItem)
{
	Inventory i;
	i.add(1, "Cola", 2.40f, 6);

	ASSERT_EQ(6, i.getAllCount());
}

TEST(InventoryTests, CountMultipleGroupedItems)
{
	Inventory i;
	i.add(3, "Cola", 2.40f, 6);

	ASSERT_EQ(18, i.getAllCount());
}

TEST(InventoryTests, GetGroupedItemName)
{
	Inventory i;
	i.add(1, "Cola", 2.40f, 6);

	for (int item = 0; item < 6; ++item)
		ASSERT_EQ("Cola", i.getItemName(item));
}

TEST(InventoryTests, GetGroupedItemUnitPrice)
{
	Inventory i;
	i.add(1, "Cola", 2.40f, 6);

	for (int item = 0; item < 6; ++item)
		ASSERT_EQ(0.40f, i.getItemPrice(item));
}

TEST(InventoryTests, CountAllSingleAndGroupedItems)
{
	Inventory i;
	i.add(3, "Chips", 3.20f, 1);
	i.add(2, "Cola", 2.40f, 6);

	ASSERT_EQ(15, i.getAllCount());
}

TEST(InventoryTests, CountIndividualItemsWithSamePrices)
{
	Inventory i;
	i.add(3, "Chips", 3.20f, 1);
	i.add(2, "Cola", 2.40f, 6);

	ASSERT_EQ(3, i.getItemCount("Chips"));
	ASSERT_EQ(12, i.getItemCount("Cola"));
}

TEST(InventoryTests, CountIndividualItemsWithDifferentPrices)
{
	Inventory i;
	i.add(1, "Chips", 3.20f, 1);
	i.add(2, "Chips", 3.00f, 1);

	ASSERT_EQ(3, i.getItemCount("Chips"));
}

TEST(InventoryTests, GetHighestPriceOfSameItem)
{
	Inventory i;
	i.add(1, "Chips", 2.80f);
	i.add(1, "Chips", 3.20f);
	i.add(1, "Chips", 2.60f);

	ASSERT_EQ(3.20f, i.getHighestPrice("Chips"));
}

TEST(InventoryTests, GetLowestPriceOfSameItem)
{
	Inventory i;
	i.add(1, "Chips", 2.80f);
	i.add(1, "Chips", 3.20f);
	i.add(1, "Chips", 2.60f);

	ASSERT_EQ(2.60f, i.getLowestPrice("Chips"));
}

TEST(InventoryTests, RemoveItemWithHighestPriceRemovesItem)
{
	Inventory i;
	i.add(1, "Cola", 2.00f);
	i.add(1, "Cola", 3.20f);
	i.removeHighestPrice("Cola");

	ASSERT_EQ(1, i.getAllCount());
}

TEST(InventoryTests, RemoveItemWithHighestPriceLeavesCheapestItem)
{
	Inventory i;
	i.add(1, "Cola", 2.00f);
	i.add(1, "Cola", 3.20f);
	i.removeHighestPrice("Cola");

	ASSERT_EQ(2.00f, i.getHighestPrice("Cola"));
}

TEST(InventoryTests, RemoveItemWithLowestPriceRemovesItem)
{
	Inventory i;
	i.add(1, "Cola", 2.00f);
	i.add(1, "Cola", 3.20f);
	i.removeLowestPrice("Cola");

	ASSERT_EQ(1, i.getAllCount());
}

TEST(InventoryTests, RemoveItemWithLowestPriceLeavesExpensiveItem)
{
	Inventory i;
	i.add(1, "Cola", 2.00f);
	i.add(1, "Cola", 3.20f);
	i.removeLowestPrice("Cola");

	ASSERT_EQ(1, i.getAllCount());
	ASSERT_EQ(3.20f, i.getLowestPrice("Cola"));
}
