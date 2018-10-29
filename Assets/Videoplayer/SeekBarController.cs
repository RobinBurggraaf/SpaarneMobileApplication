using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeekBarController : MonoBehaviour {


	public RectTransform progressBar;
	public RectTransform fill;
	public Text totalTime;
	public Text remainingTime;

	private int progressBarLength;

	// Use this for initialization
	void Start () {
		// TODO check progress bar padding and fix the value below
		//fill.sizeDelta = new Vector2(0 , fill.sizeDelta.y);
	}

	void Update(){
		float x = fill.GetComponent<RectTransform> ().sizeDelta.x;

	}
	
	public void Progress(float percent){
		fill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , progressBar.rect.width * percent);
	}


}
