using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRenderingViewport : MonoBehaviour
{


    public WebCamDevice[] devices;
    public WebCamTexture mCamera;
    public GameObject plane;
    public RawImage background;

    // Use this for initialization
    void Start () {

        devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No Cameras");
            return;
           
        }

        for (int i = 0; i < devices.Length; ++i)
        {
            if (!devices[i].isFrontFacing)
            {
                mCamera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }
        if (mCamera == null) return;
        
        mCamera.Play();
        if (plane != null)
        {
            plane.GetComponent<Renderer>().material.mainTexture = mCamera;
        }
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
