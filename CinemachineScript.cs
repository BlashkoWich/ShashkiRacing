using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineScript : MonoBehaviour
{
    CinemachineTransposer transp;
    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] GameObject particle;
    
        void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (vcam != null)
            transp = vcam.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        SpeedEffect();
    }
    private void SpeedEffect()
    {
        if (floatingJoystick.Vertical > 0.6)
        {
            transp.m_FollowOffset = new Vector3(0, 1.9f, Mathf.Lerp(transp.m_FollowOffset.z, -5f, 0.1f));
            particle.SetActive(true);
        }
        else particle.SetActive(false);
        if (floatingJoystick.Vertical == 0)
        {
            transp.m_FollowOffset = new Vector3(0, 1.9f, Mathf.Lerp(transp.m_FollowOffset.z, -4.15f, 0.1f));
        }
        if (floatingJoystick.Vertical < - 0.5)
        {
            transp.m_FollowOffset = new Vector3(0, 1.9f, Mathf.Lerp(transp.m_FollowOffset.z, -3.8f, 0.1f));
        }
    }
}
