using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToArButton : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnTask);
    }

    private void OnTask()
    {
        RememberProtocol.control.goToAr();
    }
}
