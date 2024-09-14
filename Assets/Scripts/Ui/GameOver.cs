using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    public void Setup(float meters){
        gameObject.SetActive(true);
    }
}
