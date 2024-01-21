using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingList
{
    public LinkedList<string> items;
    public LinkedList<int> quantitys;
    public LinkedList<string> types;
    public LinkedList<double> prices;

    public ShoppingList()
    {
        items = new LinkedList<string>();
        quantitys = new LinkedList<int>();
        types = new LinkedList<string>();
        prices = new LinkedList<double>();
    }

    public void AddItem(string item, int qty, string type, double price)
    {
        items.AddLast(item);
        quantitys.AddLast(qty);
        types.AddLast(type);
        prices.AddLast(price);
    }

    public void RemoveItem(string item, int qty, string type, double price)
    {
        LinkedListNode<string> node = items.Find(item);
        if (node != null)
        {
            int index = 0;
            foreach (string s in items)
            {
                if (s == item)
                {
                    break;
                }
                index++;
            }

            LinkedListNode<int> quantityNode = quantitys.Find(quantitys.ElementAt(index));
            LinkedListNode<string> typeNode = types.Find(types.ElementAt(index));
            LinkedListNode<double> priceNode = prices.Find(prices.ElementAt(index));

            quantitys.Remove(quantityNode);
            types.Remove(typeNode);
            prices.Remove(priceNode);
            items.Remove(node);
        }
    }

    public void UpdateItem(int index, string newItem, int qty, string type, double price)
    {
        if (index >= 0 && index < items.Count)
        {
            LinkedListNode<string> node = items.Find(items.ElementAt(index));
            if (node != null)
            {
                LinkedListNode<int> quantityNode = quantitys.Find(quantitys.ElementAt(index));
                LinkedListNode<string> typeNode = types.Find(types.ElementAt(index));
                LinkedListNode<double> priceNode = prices.Find(prices.ElementAt(index));

                node.Value = newItem;
                quantityNode.Value = qty;
                typeNode.Value = type;
                priceNode.Value = price;
            }
        }
    }


    public void PrintItems()
    {
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void Clear()
    {
        items.Clear();
        quantitys.Clear();
        types.Clear();
        prices.Clear();
    }



}
