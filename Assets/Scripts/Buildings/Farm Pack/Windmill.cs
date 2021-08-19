using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 3;
        baseScore = 2;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Windmill":
                return -10;

            case "Farm":
                return 3;

            case "Store":
                return -5;

            case "Skyscraper":
                return -10;

            default:
                return 0;
        }
    }
}
