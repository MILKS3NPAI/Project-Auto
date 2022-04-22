using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public static bool mouseIsOverButton = false;
    public static Dictionary<GameObject, bool> occupiedTiles = new Dictionary<GameObject, bool>();
    [SerializeField] float horizontalButtonOffset;
    [SerializeField] GameObject unitButton, spawnedUnitsParent;
    [SerializeField] GameObject tileMapObject;
    [SerializeField] Vector3 lowerLeftPosition;
    private const float SPAWN_POS_Y = 1;
    private GameObject[] unitButtonList = new GameObject[5]; // the number of units purchasable in the shop
    private int spawnableObjectsAmount;
    private List<GameObject> spawnableObjects;
    private List<GameObject> possibleTileObjects = new List<GameObject>();
    private void Start()
    {
        while (spawnableObjects == null || spawnableObjects.Count == 0)
            spawnableObjects = FindAllObjectsInGivenLayer(8); // Interactable layer
        spawnableObjectsAmount = spawnableObjects.Count; // This is the number of "Interactable" objects (to be considered as units)
        for (int i = 0; i < unitButtonList.Length; i++)
        {
            GameObject createdUnitButton = Instantiate(unitButton);
            int randomUnitIndex = Random.Range(0, spawnableObjectsAmount);
            createdUnitButton.SetActive(true);
            createdUnitButton.name = "Unit Button " + (randomUnitIndex + 1);
            createdUnitButton.transform.parent = transform;
            createdUnitButton.transform.GetChild(0).GetComponent<Text>().text = "Unit " + (randomUnitIndex + 1);
            createdUnitButton.GetComponent<ButtonClick>().SetUnitIndex(randomUnitIndex);
            unitButtonList[i] = createdUnitButton;
        }
        if (!tileMapObject)
        {
            print(name + ": tileMapObject not set");
        }
        else
        {
            for (int i = 0; i < tileMapObject.transform.childCount; i++)
            {
                if (tileMapObject.transform.GetChild(i).name.EndsWith("0"))
                {
                    //print(name + ": Added tile " + tileMapObject.transform.GetChild(i).name);
                    possibleTileObjects.Add(tileMapObject.transform.GetChild(i).gameObject);
                }
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.localPosition = lowerLeftPosition + Vector3.right * horizontalButtonOffset * i;
        }
        for (int i = 0; i < spawnableObjectsAmount; i++)
        {
            GameObject tempObj = spawnableObjects[i];
            //print(name + ": " + tempObj.name + " is at location " + tempObj.transform.position + " ; " + tempObj.transform.localPosition);
        }
        //print(name + " Occupied tiles count is " + occupiedTiles.Count);
        for (int i = 0; i < occupiedTiles.Count; i++)
        {
            //print(name + ": i = " + i + " ");
        }
    }
    // can only have 0-1 parameter (otherwise it won't show in options for OnClick() in inspector)
    public void DoButtonAction(GameObject obj)
    {
        if (obj.GetComponent<ButtonClick>()) {
            int buttonAction = obj.GetComponent<ButtonClick>().GetButtonAction();
            switch (buttonAction)
            {
                case 1: // buy xp
                    print(obj.name + ": You bought XP");
                    break;
                case 2: // refresh
                    RefreshUnitButtons();
                    break;
                case 3: // buy units
                    obj.SetActive(false);
                    mouseIsOverButton = false;
                    SpawnUnit(obj.GetComponent<ButtonClick>().GetUnitIndex());
                    break;
                default:
                    break;
            }
        }
    }
    private void SpawnUnit(int unitIndex)
    {
        //GameObject spawnedObj = Instantiate(spawnableObjects[unitIndex]); //Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count)]);
        Vector3 spawnedPosition = FindNextAvailableTile();
        if (spawnedPosition != Vector3.negativeInfinity)
        {
            GameObject spawnedObj = Instantiate(spawnableObjects[unitIndex]);
            spawnedObj.transform.position = spawnedPosition;
            spawnedObj.transform.parent = spawnedUnitsParent.transform;
        }
        else
        {
            print(name + ": Cannot spawn unit");
            //spawnedObj.transform.position = new Vector3(1.6f, SPAWN_POS_Y, 2.07f);
        }
    }
    private List<GameObject> FindAllObjectsInGivenLayer(int layer)
    {
        GameObject[] objArray = FindObjectsOfType<GameObject>();
        if (objArray == null || objArray.Length == 0)
            return null;
        else
        {
            spawnableObjects = new List<GameObject>();
            for (int i = 0; i < objArray.Length; i++)
            {
                if (objArray[i].layer == layer)
                {
                    spawnableObjects.Add(objArray[i]);
                }
            }
            //print(name + ": There are " + spawnableObjects.Count + " interactable objects");
            return spawnableObjects;
        }
    }
    private void RefreshUnitButtons()
    {
        for (int i = 0; i < unitButtonList.Length; i++)
        {
            int newUnitIndex = Random.Range(0, spawnableObjectsAmount);
            unitButtonList[i].transform.GetChild(0).GetComponent<Text>().text = "Unit " + (newUnitIndex + 1);
            unitButtonList[i].GetComponent<ButtonClick>().SetUnitIndex(newUnitIndex);
            unitButtonList[i].SetActive(true);
        }
    }
    private Vector3 FindNextAvailableTile()
    {
        for (int i = 0; i < possibleTileObjects.Count; i++)
        {
            if (!occupiedTiles.ContainsKey(possibleTileObjects[i]))
            {
                return possibleTileObjects[i].transform.position + new Vector3(0, SPAWN_POS_Y, 0);
            }
        }
        return Vector3.negativeInfinity;
    }
    public static void UpdateOccupiedTiles(Collision tile, bool addTile)
    {
        GameObject tileObj = tile.gameObject;
        if (occupiedTiles.ContainsKey(tileObj) && !addTile)
        {
            //tileObj.transform.localScale = 1f * Vector3.one;
            occupiedTiles.Remove(tileObj);
        }
        else if (!occupiedTiles.ContainsKey(tileObj) && addTile)
        {
            //tileObj.transform.localScale = 0.9f * Vector3.one;
            occupiedTiles.Add(tileObj, true);
        }
    }
    public void OnPointerEnter()
    {
        mouseIsOverButton = true;
    }
    public void OnPointerExit()
    {
        mouseIsOverButton = false;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
