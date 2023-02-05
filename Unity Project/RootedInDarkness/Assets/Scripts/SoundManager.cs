using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioSource clipSource;
    private float timer;
    private float randomAmbianceTimer;
    AudioSource effectSource;

    [SerializeField] AudioClip[] audioClips;

    private void Start()
    {
        RandomizeAmbianceTimer();
    }

    //Singleton instance 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        effectSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= randomAmbianceTimer)
        {
            PlayRandomSoundEffect();
        }
    }

    private void RandomizeAmbianceTimer()
    {
        randomAmbianceTimer = Random.Range(30, 60);
    }

    public void PlayRandomSoundEffect()
    {
        int randomIndex = Random.Range(0, audioClips.Length-1);
        effectSource.PlayOneShot(audioClips[randomIndex]);
        RandomizeAmbianceTimer();
        Debug.Log("Playing: " + audioClips[randomIndex].name);
        timer = -audioClips[randomIndex].length;
        
    }

    public void PlayAudio(AudioClip clip)
    {
        Debug.Log("Playing: " + clip.name);
        
        clipSource.PlayOneShot(clip);
        
    }


}