using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStartPartyNPC1NoKnife : MonoBehaviour
{
    
    public GameObject dialogue;
    public GameObject dialogueChoice;
 
    
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoKnifePartyNPC1")
        {
            showText();
            dialogueChoice.SetActive(true);
        }
    }

    void showText()
    {
        var color = dialogue.GetComponent<Image>().color;
        color.a = 1f;

        dialogue.GetComponent<Image>().color = color;
    }

    
}
