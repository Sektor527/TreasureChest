#include "Inventory.h"
#include <cassert>
#include <limits>
#include <algorithm>

void Inventory::add(int amount, const std::string& name, float price, int units)
{
	assert(amount > 0);
	assert(!name.empty());
	assert(price > 0.f);
	assert(units > 0);

	for (int i = 0; i < amount * units; ++i)
		items.push_back(std::make_pair<std::string, float>(name, price / units));
}

void Inventory::removeHighestPrice(const std::string& name)
{
	float price = 0;
	items_t::iterator toDelete = items.end();

	items_t::iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		std::string& itName = it->first;
		float itPrice = it->second;
		if (itName == name && itPrice > price)
		{
			price = itPrice;
			toDelete = it;
		}
	}

	assert(toDelete != items.end());

	items.erase(toDelete);
}

void Inventory::removeLowestPrice(const std::string& name)
{
	float price = std::numeric_limits<float>::max();
	items_t::iterator toDelete = items.end();

	items_t::iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		std::string& itName = it->first;
		float itPrice = it->second;
		if (itName == name && itPrice < price)
		{
			price = itPrice;
			toDelete = it;
		}
	}

	assert(toDelete != items.end());

	items.erase(toDelete);
}

int Inventory::getAllCount() const
{
	return items.size();
}

int Inventory::getItemGroupCount() const
{
	std::vector<std::string> names;

	items_t::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		if (std::find(names.begin(), names.end(), it->first) == names.end())
		{
			names.push_back(it->first);
		}
	}

	return names.size();
}

std::string Inventory::getItemGroupName(int index) const
{
	std::vector<std::string> names;

	items_t::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		if (std::find(names.begin(), names.end(), it->first) == names.end())
		{
			names.push_back(it->first);
		}
	}

	return names[index];
}

int Inventory::getItemCount(int index) const
{
	return getItemCount(getItemGroupName(index));
}

int Inventory::getItemCount(const std::string& name) const
{
	int count = 0;

	items_t::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		if (it->first == name) count++;
	}

	return count;
}

std::string Inventory::getItemName(int index) const
{
	return items[index].first;
}

float Inventory::getItemPrice(int index) const
{
	return items[index].second;
}

float Inventory::getHighestPrice(const std::string& name) const
{
	float price = 0.f;

	items_t::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		if (it->first == name)
		{
			price = std::max(price, it->second);
		}
	}

	return price;
}

float Inventory::getLowestPrice(const std::string& name) const
{
	float price = std::numeric_limits<float>::max();

	items_t::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it)
	{
		if (it->first == name)
		{
			price = std::min(price, it->second);
		}
	}

	return price;
}
