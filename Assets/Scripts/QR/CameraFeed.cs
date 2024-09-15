using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [HideInInspector] public WebCamTexture webCamTexture;
    void Start()
    {
        foreach(var camera in WebCamTexture.devices){
            if(!camera.isFrontFacing){
                webCamTexture = new WebCamTexture(camera.name);
                break;
            }
        }
        if(webCamTexture == null){
            webCamTexture = new WebCamTexture();
        }
        rawImage.texture = webCamTexture;
        rawImage.material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

}
