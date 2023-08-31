using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterObject : MonoBehaviour
{
    public static MasterObject instance;

    public SceneLoader sceneLoader { get; private set; }
    public LevelStateManager levelStateManager { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Lol someone is stupid and created a second Master Object");
            return;
        }
        DontDestroyOnLoad(this);

        // Consistent Objects
        this.sceneLoader = GetComponent<SceneLoader>();
        this.levelStateManager = GetComponent<LevelStateManager>();
    }
}
