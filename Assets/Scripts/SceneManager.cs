using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public const string MENU = "Menu";
    public const string AR = "AR";
    public const string TUTORIAL = "Tutorial";

    private List<string> loadedScenes;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        loadedScenes = new List<string>();
        loadLevel(MENU, false);
    }

    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void loadLevel(string levelName, bool force)
    {
        if (loadedScenes.Contains(levelName) && !force)
            return;
        if (force)
        {
            SceneManager.UnloadSceneAsync(levelName);
            loadedScenes.Remove(levelName);
        }

        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        loadedScenes.Add(levelName);

        for (int i = loadedScenes.Count - 1; i >= 0; i--)
        {
            if (loadedScenes[i] != levelName)
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i]);
                loadedScenes.RemoveAt(i);
                break;
            }
        }

    }
}
