using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeekBarController : MonoBehaviour {


	public RectTransform progressBar;
	public Image fill;
    public Image handle;

	public Text totalTime;
	public Text remainingTime;

	private int progressBarLength;

    private float width;

	// Use this for initialization
	void Start () {
		// TODO check progress bar padding and fix the value below
		//fill.sizeDelta = new Vector2(0 , fill.sizeDelta.y);

	    width = progressBar.rect.width;
        Debug.Log("Width is: " + width);
	}

	void Update(){
		float x = fill.GetComponent<RectTransform> ().sizeDelta.x;

	}
	
	public void Progress(float percent)
	{
	    fill.fillAmount = percent;

        // set handle equal to

	    float HandlePos =  percent * width;

	        handle.rectTransform.position = new Vector3(Mathf.Clamp(HandlePos, 0, width), handle.rectTransform.position.y, handle.rectTransform.position.z);
        Debug.Log(handle.rectTransform.position);
	    }

    }
