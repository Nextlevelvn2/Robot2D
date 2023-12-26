using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public string triggerTag;
    public CinemachineVirtualCamera primaryCam;
    public CinemachineVirtualCamera[] virtualCam;
    // Start is called before the first frame update
    void Start()
    {
        SwitchToCamera(primaryCam);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cam2")
        {
            CinemachineVirtualCamera targetCam = collision.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCam);
        }
    }
    void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach(CinemachineVirtualCamera camera in virtualCam)
        {
            camera.enabled = camera == targetCamera;
            break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "cam2")
        {
            SwitchToCamera(primaryCam);
        }
    }
}
