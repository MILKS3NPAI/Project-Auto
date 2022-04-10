using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    // using https://youtu.be/EfSImxUqmO0 
    public UnityEvent unityEvent = new UnityEvent();
    private int buttonAction = 0;
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
        /*if (Mouse.current.leftButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;*/
            /*if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(Vector3.zero, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                print(hit.collider.gameObject);
                if (hit.collider.gameObject == gameObject)
                {
                    print("WORLD");
                }
            }*/
            /*if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                print(Mouse.current.position.ReadValue());
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Mathf.Infinity, Color.yellow);
                Debug.DrawLine(Vector3.zero, transform.position, Color.red, int.MaxValue);
                //Debug.DrawLine(Mouse.current.position.ReadValue(), transform.position, Color.green, int.MaxValue);
                Debug.DrawRay(Mouse.current.position.ReadValue(), transform.position, Color.blue, int.MaxValue);
                print(hit.collider.gameObject);
            }
        }*/
    }
    /*public void ButtonMethod()
    {
        print(name + ": I was clicked");
    }*/
    public int ReturnButtonAction()
    {
        return buttonAction;
    }
}
