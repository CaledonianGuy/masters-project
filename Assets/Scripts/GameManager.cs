using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreThreshold = 20;
    [SerializeField] private int scoreThresholdCounter = 0;
    private List<InventoryItemBase> buildingList;

    [SerializeField] private GameObject[] buildings = new GameObject[12];
    [SerializeField] private Inventory inventory;
    [SerializeField] private Grid hexGrid;
    [SerializeField] private Text scoreLabel;

    private void Start()
    {
        buildingList = new List<InventoryItemBase>();
        AddNewBuildings();
        AddNewBuildings();
    }

    private void OnEnable()
    {
        InventoryItemBase.OnBuildDrop += AddToBuildingList;
    }

    private void OnDisable()
    {
        InventoryItemBase.OnBuildDrop -= AddToBuildingList;
    }

    void AddToBuildingList(InventoryItemBase item)
    {
        buildingList.Add(item);

        if (buildingList.Count > 1)
        {
            UpdateScore();
        } 
        else
        {
            score += item.baseScore;
            scoreLabel.text = score.ToString();
        }
    }

    void UpdateScore()
    {
        InventoryItemBase checkObj = buildingList[buildingList.Count - 1];

        for (int i = 0; i < buildingList.Count - 1; i++)
        {
            if (CheckDistance(checkObj.cellCoords, buildingList[i].cellCoords) < checkObj.maxRange + 1)
            {
                score += checkObj.baseScore + checkObj.RangeRules(buildingList[i]);

                if (score < 0)
                    score = 0;

                scoreLabel.text = score.ToString();
            }
        }

        if (score >= scoreThreshold)
        {
            AddNewBuildings();
            CalculateNewScoreThreshold();
        } 
    }

    int CheckDistance(Vector3 checkCell, Vector3 other)
    {
        return (Mathf.Abs((int)(checkCell.x - other.x)) + Mathf.Abs((int)(checkCell.y - other.y)) + Mathf.Abs((int)(checkCell.z - other.z))) / 2;
    }

    void AddNewBuildings()
    {
        //int pack = Random.Range(1, 3);

        int pack = 2;

        switch (pack)
        {
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    var farmPrefab = Instantiate(buildings[0]);
                    var item = farmPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    var farmlandPrefab = Instantiate(buildings[1]);
                    var item = farmlandPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    var siloPrefab = Instantiate(buildings[2]);
                    var item = siloPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 1; i++)
                {
                    var windmillPrefab = Instantiate(buildings[3]);
                    var item = windmillPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                break;

            case 2:
                for (int i = 0; i < 3; i++)
                {
                    var housePrefab = Instantiate(buildings[4]);
                    var item = housePrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 1; i++)
                {
                    var skyscraperPrefab = Instantiate(buildings[5]);
                    var item = skyscraperPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 1; i++)
                {
                    var storePrefab = Instantiate(buildings[6]);
                    var item = storePrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                for (int i = 0; i < 1; i++)
                {
                    var towerPrefab = Instantiate(buildings[7]);
                    var item = towerPrefab.GetComponent<InventoryItemBase>();

                    if (item != null)
                    {
                        item.hexGrid = hexGrid;
                        inventory.AddItem(item);
                        item.OnPickup();
                    }
                }

                break;
            case 3:
                break;
            default:
                break;
        }
    }

    void CalculateNewScoreThreshold()
    {
        scoreThreshold += 50 + scoreThresholdCounter * 10;
        scoreThresholdCounter++;
    }
}
