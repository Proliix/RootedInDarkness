using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> footstepSounds;
    [SerializeField] float distance = 5;
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
            SoundManager.Instance.PlayAudio(footstepSounds[Random.Range(0, footstepSounds.Count-1)]);
        }
    }
}
 