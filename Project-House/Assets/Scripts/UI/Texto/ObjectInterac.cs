using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class ObjectInterac : MonoBehaviour
{

    private int v = 0;
    private GameObject MessageObject;
    private bool messegeState = false;

    [SerializeField]
    private float CoolDownTime = 2.0f;
    private float NextFiretime = 0;

    [SerializeField]
    private string[] messageArray = new string[]
        {
            "message == 1",
            "message == 2",
            "message == 3",
            "message == 4",
            "message == 5",
        };

    private Text messageText;

    private void Awake()
    {
       
    }

    private void Start()
    {
        if(!messageText)
        messageText = GameObject.Find("Canvas").GetComponent<Refrences>().text;

        MessageObject = GameObject.Find("Canvas").GetComponent<Refrences>().messegeRefrence;
        //MessageObject = GameObject.Find("message");
        MessageObject.SetActive(false);
        v = 0;
        string message = messageArray[v];
        TextWriter.AddWriter_Static(messageText, message, .05f, true);
    }

    public void SkipMessage(CallbackContext context)
    {
        if (messegeState == true)
        {
            if (context.ReadValue<float>() == 1)
            {
                v++;
                if (v >= messageArray.Length)
                {
                    v = 0;
                    MessageObject.SetActive(false);
                    messegeState = false;
                    // v = 0;
                }
                messageText.text = messageArray[v];
                //string message = messageArray[v];
                //TextWriter.AddWriter_Static(messageText, message, .03f, true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (Time.time > NextFiretime)
            {
                if (messegeState == false)
                {
                    v = 0;
                    MessageObject.SetActive(true);
                    messegeState = true;
                    NextFiretime = Time.time + CoolDownTime;
                }
            }
        }
    }
}