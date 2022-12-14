using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class ObjectInterac : MonoBehaviour
{

    private int v = 0;
    private GameObject MessageObject;
    private bool messegeState ;
    public TextWriter textWriter;


    [SerializeField]
    private float CoolDownTime = 2.0f;
    private float NextFiretime = 0;

    [SerializeField]
    private string[] messageArray = new string[]
        {
            "message == 1",
        };
           

    private Text messageText;

    

    private void Start()
    {

        if (!messageText)
        messageText = GameObject.Find("Canvas").GetComponent<Refrences>().text;
        MessageObject = GameObject.Find("Canvas").GetComponent<Refrences>().messegeRefrence;

        MessageObject.SetActive(false);
        v = 0;

  
    }

       


    

    public void SkipMessage(CallbackContext context)
    {
        
        if (messegeState == true && context.ReadValue<float>() == 1)
        {
            
            
               
                v++;
                if (v >= messageArray.Length)
                {
                    v = 0;
                    MessageObject.SetActive(false);
                    messegeState = false;
                }
           
                messageText.text = messageArray[v];
                string message = messageArray[v];
                textWriter.AddWriter_Static(messageText, message, .03f, true);
            
        }
    }
                
                    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(messegeState);
        if (collision && !playerController.Instance.ChecarChave(gameObject.name))
        {
            if (Time.time > NextFiretime)
            {
                if (messegeState == false)
                {
                    
                    messegeState = true;
                    v = 0;
                    MessageObject.SetActive(true);
                    NextFiretime = Time.time + CoolDownTime;
                    string message = messageArray[v];
                    textWriter.AddWriter_Static(messageText, message, .05f, true);

                }

            }
        }
    }
}