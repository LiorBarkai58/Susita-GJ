using System.Collections;
using UnityEngine;

public class TutorialLevel : MonoBehaviour {
    [SerializeField] GameObject SlideTutorial;

    [SerializeField] GameObject text;

    [SerializeField] GameObject FiberGlass;



    void Start(){
        StartCoroutine(HideSlide());
    }
    private IEnumerator HideSlide(){
        yield return new WaitForSeconds(5);
        SlideTutorial.SetActive(false);
        text.SetActive(false);
        FiberGlass.SetActive(true);
        yield return new WaitForSeconds(5);
        FiberGlass.SetActive(false);

    }

    
}