using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyscraper : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 2;
        baseScore = 5;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Tower":
                return 8;

            case "Skyscraper":
                return 1;

            case "Windmill":
                return -5;

            case "Silo":
                return -5;

            case "Farmland":
                return -5;

            case "Farm":
                return -5;

            default:
                return 0;
        }
    }
}
