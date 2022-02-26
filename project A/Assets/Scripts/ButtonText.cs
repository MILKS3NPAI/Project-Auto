using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ButtonText : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = new Vector3(90, 0, 0);
    }
}
