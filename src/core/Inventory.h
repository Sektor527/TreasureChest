#pragma once
#include <string>
#include <vector>

class Inventory
{
public:
	void add(int amount, const std::string& name, float price, int units = 1);
	void removeHighestPrice(const std::string& name);
	void removeLowestPrice(const std::string& name);

	int getAllCount() const;
	int getItemCount(const std::string& name) const;
	std::string getItemName(int index) const;
	float getItemPrice(int index) const;
	float getHighestPrice(const std::string& name) const;
	float getLowestPrice(const std::string& name) const;

private:

	typedef std::vector<std::pair<std::string, float> > items_t;
	items_t items;
};
