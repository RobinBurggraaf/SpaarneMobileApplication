using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolSelectionUIManager : MonoBehaviour {

    public GameObject MenuCanvas;
    public GameObject SelectedProtocolCanvas;

    public Text titleBarText;
    public Image titleBarImage;


    public Text goalsHeadline;
    public Text materialsHeadline;

    public Text goals;
    public Text materials;


    public GameObject buttonAR;
    public GameObject buttonVideo;

    public void ProtocolSelected(TutorialObject t){
        Color convertedColor = t.color;


        titleBarImage.color = convertedColor;
        titleBarText.text = t.title;

        goalsHeadline.color = convertedColor;
        materialsHeadline.color = convertedColor;

        goals.text = t.goal;
        materials.text = t.materials;

        buttonAR.GetComponent<Image>().color = convertedColor;
        buttonVideo.GetComponent<Image>().color = convertedColor;
        MenuCanvas.SetActive(false);
        SelectedProtocolCanvas.SetActive(true);
        
    }


}
