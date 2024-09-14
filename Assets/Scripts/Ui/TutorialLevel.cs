using System.Collections;
using UnityEngine;

public class TutorialLevel : MonoBehaviour {
    [SerializeField] GameObject SlideTutorial;

    [SerializeField] GameObject text;



    void Start(){
        StartCoroutine(HideSlide());
    }
    private IEnumerator HideSlide(){
        yield return new WaitForSeconds(5);
        SlideTutorial.SetActive(false);
        text.SetActive(false);
    }

    
}