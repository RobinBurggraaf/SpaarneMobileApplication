using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZoomObject : MonoBehaviour {

    Vector3 temp;
    private bool hasObject;
  
    public Slider slider;
    public GameObject andyObject;

    private float originalScale=-1;

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

        Debug.Log(temp);
            //temp = andyObject.transform.localScale;
            temp.x = originalScale * slider.value;
            temp.y = originalScale * slider.value;
            temp.z = originalScale* slider.value;
            andyObject.transform.localScale = temp;
        Debug.Log("fackingandy is" + andyObject.transform.localScale);
        
    }


    // Update is called once per frame
    public void Update()
    {
        if (andyObject && originalScale == -1) {
            Debug.Log("eerste" + originalScale);
            Debug.Log("ANDyYYY" + andyObject.transform.localScale.x);
            originalScale = andyObject.transform.localScale.x;
            Debug.Log("tweede" + originalScale);
        }
    }
}
