using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoHandler : MonoBehaviour
{
    public VideoClip clip;
    public CustomVideoPlayerController videoController;

    void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick(){PlayVideo();}

    private void PlayVideo()
    {
        if (clip)
        {
            videoController.videoClip = clip;
            videoController.OpenPlayer();
        }
    }

}