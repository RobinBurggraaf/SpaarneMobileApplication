using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "new protocol", menuName = "ProtocolObjects")]
public class TutorialObject : ScriptableObject
{

    public Color32 color;
    public string title;
    public string goal;
    public string materials;

    public VideoClip video;
}
