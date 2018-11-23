using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARChange : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {   
        SceneManager.LoadScene(1);
    }
}
