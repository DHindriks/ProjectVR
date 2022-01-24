using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStart : MonoBehaviour
{

    
    float time;
    float timeDelay;
    public GameObject dialogue;
 
    void Start ()
    {
       time = 0f;
       timeDelay = 8f;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC1")
        {
            showText();
            
        }
    }

    void showText()
    {
        var color = dialogue.GetComponent<Image>().color;
        color.a = 1f;

        dialogue.GetComponent<Image>().color = color;
    }

    void Update()
     {
        
       time = time + 1f * Time.deltaTime;

       if (time>= timeDelay) 
       {

       if(dialogue != null)
       {
        if (dialogue.GetComponent<Image>().color.a > 0)
        {
            var color = dialogue.GetComponent<Image>().color;
            color.a -= 1f;
            dialogue.GetComponent<Image>().color = color;
        }
       }
       }
     }
    
}
