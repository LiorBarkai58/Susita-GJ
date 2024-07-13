using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.Common;

public class QRCodeReader : MonoBehaviour
{
    public CameraFeed cameraFeed;
    private IBarcodeReader barcodeReader;
    // Start is called before the first frame update
    void Start()
    {
        barcodeReader = new BarcodeReader{
            AutoRotate = true,
            Options = new DecodingOptions
            {
                TryHarder = true
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraFeed.webCamTexture.width > 100 && cameraFeed.webCamTexture.height > 100)
        {
            try
            {
                var result = barcodeReader.Decode(cameraFeed.webCamTexture.GetPixels32(), cameraFeed.webCamTexture.width, cameraFeed.webCamTexture.height);
                if (result != null)
                {
                    Debug.Log("QR Code Detected: " + result.Text);
                }
            }
            catch
            {
                // handle errors
            }
        }
    }
}
