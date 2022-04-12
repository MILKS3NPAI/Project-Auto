using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    // using https://youtu.be/EfSImxUqmO0 
    public UnityEvent unityEvent = new UnityEvent();
    private int buttonAction;
    private int unitIndex;
    private void Start()
    {
        if (name.ToLower().Contains("buy"))
        {
            buttonAction = 1;
        }
        else if (name.ToLower().Contains("refresh"))
        {
            buttonAction = 2;
        }
        else if(name.ToLower().Contains("unit")){
            buttonAction = 3;
        }
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Mouse.current.leftButton.isPressed)
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                print(name + ": Hit");
                unityEvent.Invoke();
            }
        }
    }
    public int GetButtonAction()
    {
        return buttonAction;
    }
    public int GetUnitIndex()
    {
        return unitIndex;
    }
    public void SetUnitIndex(int index)
    {
        unitIndex = index;
    }
}
