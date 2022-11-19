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
        messageText = GameObject.Find("Principal").transform.Find("Canvas").transform.Find("message").Find("TextMessage").GetComponent<Text>();
        MessageObject = GameObject.Find("message");
        MessageObject.SetActive(false);


    }

    private void Start()
    {
        string message = messageArray[v];
        TextWriter.AddWriter_Static(messageText, message, .05f, true);
    }

    public void SkipMessage(CallbackContext context)
    {
        if(messegeState == true)
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

                //Debug.Log("SkipMessage is Beeing Called");
                string message = messageArray[v];
                TextWriter.AddWriter_Static(messageText, message, .03f, true);

                //Debug.Log(v);
            }
        }
        /*
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

            //Debug.Log("SkipMessage is Beeing Called");
            string message = messageArray[v];
            TextWriter.AddWriter_Static(messageText, message, .05f, true);

            //Debug.Log(v);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (messegeState == false)
            {
                //Debug.Log("Apere is Working aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                v = 0;
                MessageObject.SetActive(true);
                messegeState = true;
            }
            /*
            else
            {
                //Debug.Log("DesApere is Working FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                MessageObject.SetActive(false);
                messegeState = false;
            }
            */
        }
    }
}