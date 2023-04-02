using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    RectTransform rt;
    public Vector3[] v = new Vector3[4];
    public bool[] filled = new bool[4];
    private DragDrop dragDrop;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        rt.GetLocalCorners(v);
        eventData.pointerDrag.transform.SetParent(rt);
        dragDrop = eventData.pointerDrag.gameObject.GetComponent<DragDrop>();
        if (eventData.pointerDrag != null) {
            Vector2 curr;
            for (int i = 0; i < 4; i++) {
                int cornerIndex = (i + 3) % 4; // start from bottom right, then bottom left, then top left, and top right
                if (filled[cornerIndex] == false) {
                    curr = v[cornerIndex];
                    filled[cornerIndex] = true;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = curr;
                    dragDrop.index = cornerIndex;
                    break;
                }
            }
        }        
    }
}
