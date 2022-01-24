using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour
{
    [SerializeField]
    GameObject MsgContainer;

    [SerializeField]
    GameObject ChoiceContainer;

    [SerializeField]
    GameObject Msgprefab;

    [SerializeField]
    GameObject Replyprefab;

    [SerializeField]
    TextMsg StartConvo;

    private void Start()
    {
        recieveMSG(StartConvo);
    }

    public void recieveMSG(TextMsg message)
    {
        GameObject NewMsg = Instantiate(Msgprefab, MsgContainer.transform);
        NewMsg.GetComponent<PhoneMsgScript>().Settext(message.Text);
        NewMsg.transform.SetAsFirstSibling();
        MsgContainer.GetComponentInParent<ScrollRect>();
        if (message.Response != null && message.Response.Count > 0)
        {
            StartCoroutine(TextDelay(message.Response[0], 15));
            recieveMSG(message.Response[0]);
        }

        foreach(Transform choice in ChoiceContainer.transform)
        {
            Destroy(choice.gameObject);
        }

        if (message.Options != null && message.Options.Count > 0)
        {
            foreach(TextMsg option in message.Options)
            {
                GameObject NewChoice = Instantiate(Replyprefab, ChoiceContainer.transform);
                NewChoice.GetComponent<PhoneMsgScript>().ContainedMsg = option;
                NewChoice.GetComponent<PhoneMsgScript>().Settext(option.Text);
                NewChoice.GetComponent<Button>().onClick.AddListener(delegate { recieveMSG(option); });
            }
        }
    }


    IEnumerator TextDelay (TextMsg message, float DelaySeconds)
    {
        yield return new WaitForSeconds(DelaySeconds);
        recieveMSG(message);

    }

}



[System.Serializable]
public class TextMsg
{
    //public string Sender;
    public string Text;
    public List<TextMsg> Options;
    public List<TextMsg> Response;
    public TextMsg(string sender, string text, List<TextMsg> options = null, List<TextMsg> response = null)
    {
        //Sender = sender;
        Text = text;
        Options = options;
        Response = response;
    }

}