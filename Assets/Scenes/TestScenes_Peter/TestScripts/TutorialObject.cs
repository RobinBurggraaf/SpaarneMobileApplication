using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new tutorialObject", menuName = "TutorialObjects")]
public class TutorialObject : ScriptableObject {

    public string title;
    public string description;

    public Sprite image;
}
