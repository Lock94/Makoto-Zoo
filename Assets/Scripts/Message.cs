using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    private Text msgName;
    private Text msgValue;

    private void Start()
    {
        msgName = transform.Find("MsgName").GetComponent<Text>();
        msgValue = transform.Find("MsgValue").GetComponent<Text>();
    }

    public void SetMessage(string name,string value)
    {
        msgName.text = name;
        msgValue.text = value;
    }
}
