using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 3;
        baseScore = 4;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Farmland":
                return 5;

            case "Windmill":
                return 3;

            case "Silo":
                return 5;

            case "Farm":
                return -15;

            case "Store":
                return -5;

            case "Skyscraper":
                return -5;

            default:
                return 0;
        }
    }
}
