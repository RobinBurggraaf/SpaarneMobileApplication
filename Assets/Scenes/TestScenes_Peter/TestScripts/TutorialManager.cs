using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour {

    public TextMeshProUGUI  title;
    public TextMeshProUGUI description;
    public GameObject[] imageHolders;

    public TutorialObject[] slides;

    int currentSlide = -1;
    int finalSlide;

    private void Start()
    {
        finalSlide = slides.Length;
        NextPanel();
    }



    // too tired to make it right

    public void NextPanel()
    {
        if(currentSlide < finalSlide)
        {
            if(currentSlide >= 0)
            {
                foreach(GameObject g in imageHolders)
                {
                    g.SetActive(true);
                }
            }

            currentSlide++;
            if (currentSlide > 0)
                imageHolders[currentSlide].GetComponent<Image>().sprite = slides[currentSlide].image;
            title.text = slides[currentSlide].title;
            description.text = slides[currentSlide].description;
        }
    }
	
}
