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
        if (!control) {
            DontDestroyOnLoad(gameObject);
            control = this;

        }
        else if (control)
        {
            Destroy(gameObject);
        }
    }


    public void backToProtocol()
    {
        SceneManager.LoadScene(0);
    }
}
