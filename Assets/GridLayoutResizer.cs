using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutResizer : MonoBehaviour
{

    public GameObject gridContainer;

	void Start ()
	{
	    Vector2 gridSize = gridContainer.GetComponent<RectTransform>().rect.size;
        Debug.Log("gridsize: " + gridSize);
	    float height = (gridSize.y / 4) - (gridSize.y * .05f);
	    float width = gridSize.x - (gridSize.x * .1f);
        Vector2 newSize = new Vector2(gridSize.x, height);
	    gridContainer.GetComponent<GridLayoutGroup>().cellSize = newSize;
	}
}
