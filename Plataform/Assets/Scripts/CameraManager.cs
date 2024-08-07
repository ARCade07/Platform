using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    CinemachineVirtualCamera[] cameras;

    // Start is called before the first frame update
    void Start()
    {        
        cameras = FindObjectsOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraSwitch(CinemachineVirtualCamera cam)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if(cam == cameras[i])
            {
                cameras[i].Priority = 10;
            }
            else
            {
                cameras[i].Priority = 0;
            }
        }
    }
}
