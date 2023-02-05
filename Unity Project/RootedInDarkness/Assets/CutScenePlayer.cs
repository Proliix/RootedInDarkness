using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutScenePlayer : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] bool shutdown;
    VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        if (shutdown)
        {
            Application.Quit();
        }

        SceneManager.LoadScene(sceneNumber);
    }
}
