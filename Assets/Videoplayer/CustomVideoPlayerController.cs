using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomVideoPlayerController : MonoBehaviour {

	public VideoPlayer videoPlayer;
	public RawImage videoScreen;
	public SeekBarController seekBar;
	private VideoClip _videoClip;
	private double videoDuration;


    // buttons and such
	public Image PlayButtonIcon;
	public Sprite PlayButton;
    public Sprite PauseButton;

    public  List<Button> interactables;

    public CanvasGroup ButtonGroup;



    public bool playOnStart = true;

	private AudioSource audioSource;
	private bool fadeAway;
	private bool isShowing;
	private float time;
    [SerializeField]
    private float seekbarDuration = 5f;

	public VideoClip videoClip{
		get {
			return _videoClip;
		}
		set{
			_videoClip = value;
			//Set Audio Output to AudioSource
			videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
			audioSource = gameObject.GetComponent<AudioSource>();
			//Assign the Audio from Video to AudioSource to be played
			videoPlayer.EnableAudioTrack(0, true);
			videoPlayer.SetTargetAudioSource(0, audioSource);
            videoPlayer.clip = _videoClip;
            double length = videoPlayer.frameCount / videoPlayer.frameRate;
          videoPlayer.Prepare();
			//if(videoPlayer.clip != null) seekBar.totalTime.text = GetTimeString (videoClip.length);
            createRenderTexture ();
			videoDuration = videoClip.length;
		}
	}

	void Awake()
	{
	    videoPlayer.loopPointReached += OnMovieFinished;
    }

	void Update(){
	    Seek ();
	}

	public void toggleSeekbar () {
		StopCoroutine (toggleSeekbarVisibility ());
		StartCoroutine (toggleSeekbarVisibility ());
	}

	public IEnumerator toggleSeekbarVisibility () {
		fadeAway = !fadeAway;
		if (fadeAway) { // From opaque to transparent
			for (float i = 1; i >= -0.25f; i -= Time.deltaTime * 2f) {
				ButtonGroup.alpha = i;
				yield return null;
			}

		    foreach (Button b in interactables)
		    {
		        b.interactable = false;
		    }
		} else { // From transparent to opaque
			for (float i = 0; i <= 1; i += Time.deltaTime * 2f) {
			    ButtonGroup.alpha = i;
				yield return null;
			}
		    foreach (Button b in interactables)
		    {
		        b.interactable = true;
		    }
        }
	}

	private void createRenderTexture(){
        Debug.Log("setting render texture");
		RenderTexture renderTexture = new RenderTexture ((int)720, (int)480, 24); 
		videoPlayer.targetTexture = renderTexture;
		videoScreen.texture = renderTexture;
	}
	
	public void ToggleVideoPlay(){
		if (!videoPlayer.clip)
			return;

		if (videoPlayer.isPlaying) {
			videoPlayer.Pause ();
			time = 0;
			PlayButtonIcon.sprite = PauseButton;
		} else {
			videoPlayer.Play ();
			PlayButtonIcon.sprite = PlayButton;
		}
	}

	public void Rewind(){
		videoPlayer.time = (videoPlayer.time > 5) ? videoPlayer.time - 5 : 0;
	}

	public void FastForward(){
		videoPlayer.time = (videoPlayer.time < videoClip.length - 5) ? videoPlayer.time + 5 : videoClip.length;
	}

    private void Seek()
    {
        if (videoPlayer.isPrepared)
        {
            seekBar.Progress((float) videoPlayer.frame / videoPlayer.frameCount);
          //  seekBar.remainingTime.text = GetTimeString(videoPlayer.time);
        }
    }
		
	public void changeTime(float nTime) {
		if (videoPlayer.isPrepared) {
			videoPlayer.frame = (int)(nTime * videoPlayer.frameCount);
			Seek ();
		}
	}

	public void ClosePlayer(){
		videoPlayer.Stop ();
		videoPlayer.time = 0;
		gameObject.SetActive (false);
	}

    public void OpenPlayer()
    {
        OnMovieStart();
        ButtonGroup.alpha = 1;
        videoPlayer.time = 0;
        gameObject.SetActive(true);
        if (playOnStart)
        {
            videoPlayer.playOnAwake = true;
            videoPlayer.Play();
        }
    }

    private string GetTimeString(double seconds){
		System.TimeSpan time = System.TimeSpan.FromSeconds(seconds);
		System.DateTime dateTime = System.DateTime.Today.Add(time);
		return dateTime.ToString("mm:ss");
	}

    private void OnMovieStart()
    {
        //rotate orientation naar landscape
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void OnMovieFinished(VideoPlayer v)
    {
        //rotate orientation terug naar portrait
        ClosePlayer();
        Screen.orientation = ScreenOrientation.Portrait;
        
    }
}