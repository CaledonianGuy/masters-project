using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 5;
        baseScore = 10;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Tower":
                return -30;

            default:
                return 0;
        }
    }
}
