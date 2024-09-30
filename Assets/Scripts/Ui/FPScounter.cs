using TMPro;
using UnityEngine;

namespace Ui
{
    public class FPScounter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        private float[] frameRateArray = new float[50];
        private int frameIndex;
        
        void Update()
        {
            frameRateArray[frameIndex] = Time.deltaTime;
            frameIndex = (frameIndex + 1) % frameRateArray.Length;

            text.SetText(((int)CalculateFPS()).ToString());
        }
        private float CalculateFPS(){
            float total = 0;
            foreach(float deltaTime in frameRateArray){
                total += deltaTime;
            }
            return frameRateArray.Length/total;
        }
    }
}
