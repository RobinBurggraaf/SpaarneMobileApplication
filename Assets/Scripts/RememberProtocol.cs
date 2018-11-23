using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RememberProtocol : MonoBehaviour {


    public static RememberProtocol control;
    public TutorialObject protocol;
    public bool fromAR;

    private void Awake()
    {
        if (control = null) {
            DontDestroyOnLoad(gameObject);
            control = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void goToAr() {
        fromAR = false;
        SceneManager.LoadScene(1);
    }
    public void backToProtocol()
    {
        fromAR = true;
        SceneManager.LoadScene(0);
        
        Debug.Log("sceneloadedbitches");

    }
}
