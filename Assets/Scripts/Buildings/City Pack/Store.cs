using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 2;
        baseScore = 1;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Tower":
                return 5;

            case "Store":
                return -10;

            case "Skyscraper":
                return 3;

            case "House":
                return 5;

            default:
                return 0;
        }
    }
}
