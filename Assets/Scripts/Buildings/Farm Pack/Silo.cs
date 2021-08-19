using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silo : InventoryItemBase
{
    private void Awake()
    {
        maxRange = 1;
        baseScore = -1;
    }

    public override int RangeRules(InventoryItemBase other)
    {
        switch (other.itemName)
        {
            case "Silo":
                return 3;

            case "Farm":
                return 3;

            default:
                return 0;
        }
    }
}
