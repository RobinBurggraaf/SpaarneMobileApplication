using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalContentFitter : MonoBehaviour {


    public GameObject gridContainer;

    public bool isAnchorTop = false;

    public float percentage;

    void Start()
    {
        Vector2 gridSize = gridContainer.GetComponent<RectTransform>().rect.size;
        float height = (gridSize.y * (percentage / 100));
        float width = gridSize.x - (gridSize.x * .1f);
        Vector2 newSize = new Vector2(gridSize.x, height);
        GetComponent<RectTransform>().sizeDelta = newSize;
        if (isAnchorTop)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-height*.5f);
        }
    }

}

