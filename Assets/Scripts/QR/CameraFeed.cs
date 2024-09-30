using UnityEngine;
using UnityEngine.UI;

namespace QR
{
    public class CameraFeed : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;
        [HideInInspector] public WebCamTexture webCamTexture;

        private WebCamDevice device;
        void Start()
        {
            foreach(var camera in WebCamTexture.devices)
            {
                //Debug.Log($"{camera.name}, {camera.isFrontFacing}");
                if (camera.isFrontFacing) continue;
            
                webCamTexture = new WebCamTexture(camera.name);
                device = camera;
                break;
            }
            if(webCamTexture == null){
                webCamTexture = new WebCamTexture();
            }
            rawImage.texture = webCamTexture;
            rawImage.material.mainTexture = webCamTexture;
            webCamTexture.Play();
        }
        void Update()
        {
            if (!device.isFrontFacing) return;
        
            foreach(var camera in WebCamTexture.devices)
            {
                //Debug.Log($"{camera.name}, {camera.isFrontFacing}");
                if (camera.isFrontFacing) continue;
                
                webCamTexture = new WebCamTexture(camera.name);
                break;
            }
        }

    }
}
