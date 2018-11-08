using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolSelectionUIManager : MonoBehaviour {

    public GameObject MenuCanvas;
    public GameObject SelectedProtocolCanvas;
    public Text title;
    public Text goal;
    public Text materials;
    public GameObject buttonAR;
    public GameObject buttonVideo;
    public Image titleBar;

    public void ProtocolSelected(TutorialObject t){

        title.text = t.title;
        goal.text = t.goal;
        materials.text = t.materials;

        buttonAR.GetComponent<Image>().color = t.color;
        //insert AR shit here
        buttonVideo.GetComponent<Image>().color = t.color;
        //insert Video shit here
        titleBar.color = t.color;
        SelectedProtocolCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }


}
