using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui
{
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
}