using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ProtocolSelectionUIManager : MonoBehaviour
{


    public GameObject singleton;
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
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    public void ProtocolSelected(TutorialObject t){
        Color convertedColor = t.color;

        Debug.Log("start");
        titleBarImage.color = convertedColor;
        titleBarText.text = t.title;

        goalsHeadline.color = convertedColor;
        materialsHeadline.color = convertedColor;

        goals.text = t.goal;
        goals.color = convertedColor;

        materials.text = t.materials;
        materials.color = convertedColor;
        Debug.Log(buttonAR);
        buttonAR.GetComponent<Image>().color = convertedColor;
        buttonVideo.GetComponent<Image>().color = convertedColor;
        buttonVideo.GetComponent<VideoHandler>().clip = t.video;
        MenuCanvas.SetActive(false);
        SelectedProtocolCanvas.SetActive(true);
        RememberProtocol.control.protocol = t;
        Debug.Log("End");
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

    public void GoToAR()
    {
        RememberProtocol.control.fromAR = true;
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        player.loopPointReached -= OnMovieFinished;
        SceneManager.LoadScene(1);
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(!RememberProtocol.control)
        Instantiate(singleton);
        Scene currentScene = SceneManager.GetActiveScene();
            if (RememberProtocol.control && RememberProtocol.control.fromAR)
            {
                ProtocolSelected(RememberProtocol.control.protocol);
                Debug.Log("wat");
            }
    }
}
