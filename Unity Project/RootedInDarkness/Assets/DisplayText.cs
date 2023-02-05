using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    bool displaying;
    [SerializeField] TextMeshProUGUI text;
    public void SetMessage(string input, float time)
    {
        text.text = input;

        if (displaying)
        {
            CancelInvoke(methodName: "ClearMessage");
        }

        displaying = true;
        Invoke(methodName: "ClearMessage", time);
    }

    public void ClearMessage()
    {
        displaying = false;
    }
}
