using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZoomObject : MonoBehaviour {

    Vector3 temp;
    private bool hasObject;
  
    public Slider slider;
    public GameObject andyObject;

    // lock slider value betwen 1 and 5
    // Slider event OnValueChanged() 
    // localScale x/y/z += 1. * value of slider

    private void Start()
    {
        slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }
    public void OnValueChanged()
    {
        if (!andyObject) return;

            Debug.Log(slider.value);
            temp = andyObject.transform.localScale;
            temp.y = slider.value;
            temp.x = slider.value;
            temp.z = slider.value;
            andyObject.transform.localScale = temp;
        
    }


    // Update is called once per frame
    public void Update()
    {

    }
}
