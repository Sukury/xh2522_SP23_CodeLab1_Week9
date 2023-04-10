using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryExample : MonoBehaviour
{
    public Text display;

    
    public void Update()
    {
        DisplayResources();
        DisplayItems();
    }

    private Dictionary<string, int> resourcesOwned = new Dictionary<string, int>();
    private Dictionary<string, int> itemsOwned = new Dictionary<string, int>();

    public void AddResource(string resourceType, int amountToAdd)
    {
        if (resourcesOwned.ContainsKey(resourceType))
        {
            resourcesOwned[resourceType] = resourcesOwned[resourceType] + amountToAdd;
            
            Debug.Log("You own " + resourcesOwned[resourceType] + " of " + resourceType);
        }
        else
        {
            resourcesOwned.Add(resourceType, amountToAdd);
        }
    }

    public bool RemoveResource(string resourceType, int cost)
    {
        if (!HasEnoughResources(resourceType, cost))
        {
            return false;
        }

        resourcesOwned[resourceType] = resourcesOwned[resourceType] - cost;

        if (resourcesOwned[resourceType] == 0)
            resourcesOwned.Remove(resourceType);
        
        return true;
    }

  
    public bool HasEnoughResources(string resourceType, int amount)
    {
        if (!resourcesOwned.ContainsKey(resourceType) || resourcesOwned[resourceType] < amount)
            return false;

        return true;
    }

    public void AddResources(string resourceString)
    {
        AddResource(resourceString, 10);
    }

    public void DisplayResources()
    {
        display.text = "Owned Resources:";

        //keyValuePair: Key and Value here as "String" and "int", "order" and "content". convert any datatype to any datatype
        foreach (KeyValuePair<string, int> keyValuePair in resourcesOwned)
        {
            //the keyValuePair.key means the "sting" in the dictionary 
            display.text += "\n" + keyValuePair.Key + " (" + resourcesOwned[keyValuePair.Key] + ")"; 
        }
    }

    public void DisplayItems()
    {
        display.text += "\n\nItems:";
        
        foreach (var keyValuePair in itemsOwned)
        {
            display.text += "\n" + keyValuePair.Key + " (" + itemsOwned[keyValuePair.Key] + ")";
        }
    }

    // Used by the buttons to buy an item
    public void BuyItem(string item)
    {
        // the default is false(bool), can not buy anything because no resource yet
        var successfulPurchase = false;

        switch (item.ToUpper())
        {
            case "LOVE" :
                successfulPurchase = RemoveResource("GOLD", 5);
                break;
            case "HEAL" :
                successfulPurchase = RemoveResource("GOLD", 5);
                break;
            case "MANA" :
                successfulPurchase = RemoveResource("GOLD", 10);
                break;
            case "POISON" :
                successfulPurchase = RemoveResource("GOLD", 15);
                break;
            case "ENERGY" :
                successfulPurchase = RemoveResource("GOLD", 10);
                break;
        }

        if (successfulPurchase)
        {
            //有key, add value
            if (itemsOwned.ContainsKey(item.ToUpper()))
            {
                itemsOwned[item.ToUpper()] = itemsOwned[item.ToUpper()] + 1;
            }
            //没有key, add both key and value
            else
            {
                itemsOwned.Add(item.ToUpper(), 1);
            }
        }
    }
}
