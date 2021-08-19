using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 2;
        baseScore = 0;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Tower":
                return 5;

            case "Store":
                return 5;

            case "Skyscraper":
                return 5;

            case "Windmill":
                return 3;

            case "Silo":
                return -5;

            default:
                return 0;
        }
    }
}
