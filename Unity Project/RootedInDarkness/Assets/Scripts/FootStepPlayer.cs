using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> footstepSounds;
    [SerializeField] float distance = 5;
    int lastSound = -1;
    Vector3 cachedPos;
    // Start is called before the first frame update
    void Start()
    {

        cachedPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs((cachedPos - transform.position).magnitude) > distance)
        {
            cachedPos = transform.position;
            int r = Random.Range(0, footstepSounds.Count);
            
            if(r == lastSound)
            {
                r++;
            }

            if(r >= footstepSounds.Count)
            {
                r = 0;
            }

            SoundManager.Instance.PlayAudio(footstepSounds[r]);
            lastSound = r;
        }
    }
}
 