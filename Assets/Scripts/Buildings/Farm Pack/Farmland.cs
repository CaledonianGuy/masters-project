using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmland : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 1;
        baseScore = -2;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Farmland":
                return 1;

            case "Farm":
                return 5;

            case "Store":
                return -5;

            case "Skyscraper":
                return -5;

            default:
                return 0;
        }
    }
}
