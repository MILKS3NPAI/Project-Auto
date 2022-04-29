using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitProbabilityText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int amount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Text>().text.Length > 0)
            {
                amount++;
            }
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 20 * amount);
        switch (amount)
        {
            case 3:
                transform.GetChild(0).localPosition = 20 * Vector3.up;
                transform.GetChild(1).localPosition = 0 * Vector3.up;
                transform.GetChild(2).localPosition = -20 * Vector3.up;
                break;
            case 2:
                transform.GetChild(0).localPosition = 10 * Vector3.up;
                transform.GetChild(1).localPosition = -10 * Vector3.up;
                break;
            case 1:
                transform.GetChild(0).localPosition = 0 * Vector3.up;
                break;
        }
    }
}
