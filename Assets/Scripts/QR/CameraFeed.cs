using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [HideInInspector] public WebCamTexture webCamTexture;

    private WebCamDevice device;
    void Start()
    {
        foreach(var camera in WebCamTexture.devices){
            Debug.Log($"{camera.name}, {camera.isFrontFacing}");
            if(!camera.isFrontFacing){
                webCamTexture = new WebCamTexture(camera.name);
                device = camera;
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
    void Update(){
        if(device.isFrontFacing){
            foreach(var camera in WebCamTexture.devices){
                Debug.Log($"{camera.name}, {camera.isFrontFacing}");
                if(!camera.isFrontFacing){
                    webCamTexture = new WebCamTexture(camera.name);
                    break;
                }
            }
        }
    }

    

    void OnApplicationFocus(bool hasFocus){
        if(enabled){
            if(hasFocus){
                webCamTexture.Play();
            }
            else{
                webCamTexture.Stop();
            }
        } 
    }

    void OnDisable(){
        webCamTexture.Stop();
    }

    

}
