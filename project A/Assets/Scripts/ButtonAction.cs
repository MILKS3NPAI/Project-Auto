using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] Vector3 lowerLeftPosition;
    [SerializeField] float horizontalButtonOffset;
    private List<GameObject> spawnableObjects;
    private void Start()
    {
        while (spawnableObjects == null || spawnableObjects.Count == 0)
            spawnableObjects = FindAllObjectsInGivenLayer(8); // Interactable layer
    }
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.localPosition = lowerLeftPosition + Vector3.right * horizontalButtonOffset * i;
        }
    }
    // can only have 0-1 parameter (otherwise it won't show in options for OnClick() in inspector)
    public void DoButtonAction(GameObject obj)
    {
        //print(obj.name + ": I was clicked using " + name + "'s script");
        if (obj.GetComponent<ButtonClick>()) {
            int buttonAction = obj.GetComponent<ButtonClick>().ReturnButtonAction();
            switch (buttonAction)
            {
                case 1: // buy xp
                    print(obj.name + ": You bought XP");
                    break;
                case 2: // refresh
                    print(obj.name + ": You refreshed");
                    break;
                case 3: // buy units
                    print(obj.name + ": You bought a unit");
                    obj.SetActive(false);
                    SpawnUnit();
                    break;
                default:
                    break;
            }
        }
    }
    private void SpawnUnit()
    {
        GameObject spawnedObj = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count)]);
        spawnedObj.transform.position = new Vector3(1.6f, 5, 2.07f);
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
            print(name + ": There are " + spawnableObjects.Count + " interactable objects");
            return spawnableObjects;
        }
    }
}
