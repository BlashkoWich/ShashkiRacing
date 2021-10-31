using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCarScript : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick;
void Update()
    {
        if(floatingJoystick.Horizontal > 0 && transform.rotation.y < 4)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, floatingJoystick.Horizontal * 4, 0), 1);
        if(floatingJoystick.Horizontal < 0 && transform.rotation.y > -4)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, floatingJoystick.Horizontal * 4, 0), 1);

    }
}
