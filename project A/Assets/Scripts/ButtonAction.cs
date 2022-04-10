using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    // 1 = buy xp, 2 = refresh, 3 = units
    // can only have 0-1 parameter (otherwise it won't show in options for OnClick() in inspector)
    public void DoButtonAction(GameObject obj)
    {
        print(obj.name + ": I was clicked using " + name + "'s script");
        if (obj.GetComponent<ButtonClick>()) {
            print("and its specific action is " + obj.GetComponent<ButtonClick>().ReturnButtonAction());
        }
    }
}
