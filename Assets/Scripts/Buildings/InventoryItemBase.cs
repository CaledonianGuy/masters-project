using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour
{
    public string itemName;
    public Sprite image;
    public Vector3 cellCoords;
    public int maxRange;
    public int baseScore;

    public Grid hexGrid;

    public delegate void DropAction(InventoryItemBase building);
    public static event DropAction OnBuildDrop;

    public InventorySlot Slot 
    { 
        get; set;
    }

    public virtual bool OnDrop()
    {
        Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(rayOrigin, Vector2.zero);

        bool ColliderNotPoly = false;

        foreach (var hit in hitInfo)
        {
            if (hit.collider.GetType() == typeof(PolygonCollider2D))
            {
                ColliderNotPoly = true;
            }
        }

        if (hitInfo.Length != 0 && ColliderNotPoly == false)
        {
            gameObject.SetActive(true);

            Vector3 mouseWorldPos = new Vector3(rayOrigin.x, rayOrigin.y, 0);
            Vector3Int cell = hexGrid.WorldToCell(mouseWorldPos);

            gameObject.transform.position = hexGrid.GetCellCenterWorld(cell);

            cellCoords = new Vector3(cell.x - (cell.y - (Mathf.Abs(cell.y) % 2)) / 2, -(cell.x - (cell.y - (Mathf.Abs(cell.y) % 2)) / 2) - cell.y, cell.y);

            if (OnBuildDrop != null)
            {
                OnBuildDrop(this);
            }

            return true;
        }

        return false;
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual int RangeRules(InventoryItemBase other)
    {
        return 0;
    }
}
