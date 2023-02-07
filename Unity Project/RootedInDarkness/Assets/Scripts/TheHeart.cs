using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheHeart : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerIgnoreRaycast;
        SceneManager.LoadScene("cutsceneEnd");
        //StartCoroutine(WaitForEnd());
    }
    
    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("cutsceneEnd");
    }
}
