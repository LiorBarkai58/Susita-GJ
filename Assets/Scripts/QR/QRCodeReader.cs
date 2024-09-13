using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZXing;
using ZXing.Common;

public class QRCodeReader : MonoBehaviour
{
    public CameraFeed cameraFeed;
    private IBarcodeReader barcodeReader;

    public static Dictionary<string, int> gameLevels = new Dictionary<string, int>()
    {
        ["Level 1"] = 1,
        ["Level 2"] = 2,
        ["Level 3"] = 3
    };
    
    void Start()
    {
        // PlayerPrefs.SetInt("1", 1); this line is for testing before we have the haifa level
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
                    if (gameLevels.TryGetValue(result.Text, out int value))
                    {
                        if(value == 1){
                            SceneManager.LoadScene(value);
                        }
                        else if(PlayerPrefs.GetInt($"{value-1}", 0) == 1){
                            SceneManager.LoadScene(value);
                        }
                    }
                    else
                    {
                        // catch fail
                    }
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
