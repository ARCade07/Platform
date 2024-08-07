using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NextRoom : MonoBehaviour
{
    [SerializeField] Transform nextPosition;
    [SerializeField] CinemachineVirtualCamera nextCam;
    CameraManager cameraManager;

    public int enemies;

    // Start is called before the first frame update
    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && enemies <= 0)
        {
            collision.transform.position = nextPosition.position;
            cameraManager.CameraSwitch(nextCam);
            FindObjectOfType<Player>().respawnPosition = collision.transform.position;
        }
    }
}
