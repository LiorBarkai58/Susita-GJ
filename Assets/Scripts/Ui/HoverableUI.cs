
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoverableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool UIHovered = false;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIHovered = false;
    }
}