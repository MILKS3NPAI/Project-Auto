using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] Vector3 lowerLeftPosition;
    [SerializeField] float horizontalButtonOffset;
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
                    print(obj.name + ": XP");
                    break;
                case 2: // refresh
                    print(obj.name + ": REFRESH");
                    break;
                case 3: // buy units
                    print(obj.name + ": UNITS");
                    break;
                default:
                    break;
            }
        }
    }
}
