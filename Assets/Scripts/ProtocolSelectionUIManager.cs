﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProtocolSelectionUIManager : MonoBehaviour
{

    public VideoPlayer player;

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

    void Awake()
    {
        player.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    public void ProtocolSelected(TutorialObject t){
        Color convertedColor = t.color;


        titleBarImage.color = convertedColor;
        titleBarText.text = t.title;

        goalsHeadline.color = convertedColor;
        materialsHeadline.color = convertedColor;

        goals.text = t.goal;
        goals.color = convertedColor;

        materials.text = t.materials;
        materials.color = convertedColor;

        buttonAR.GetComponent<Image>().color = convertedColor;
        buttonVideo.GetComponent<Image>().color = convertedColor;
        buttonVideo.GetComponent<VideoHandler>().clip = t.video;
        MenuCanvas.SetActive(false);
        SelectedProtocolCanvas.SetActive(true);

        
    }

    public void BackToSelectionMenu()
    {
        SelectedProtocolCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        GetComponent<MenuProtocolSelector>().ResetButtons();
    }

   public void OpenVideo()
    {
        SelectedProtocolCanvas.SetActive(false);
    }

    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        // turn on previous screen.
        Screen.orientation = ScreenOrientation.Portrait;
        SelectedProtocolCanvas.SetActive(true);
    }
}
