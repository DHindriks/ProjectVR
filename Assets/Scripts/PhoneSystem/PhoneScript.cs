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
        if (message.Response != null)
        {
            recieveMSG(message.Response);
        }

        foreach(Transform choice in ChoiceContainer.transform)
        {
            Destroy(choice.gameObject);
        }

        if (message.Options != null)
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
}



[System.Serializable]
public class TextMsg
{
    public string Sender;
    public string Text;
    public List<TextMsg> Options;
    public TextMsg Response;
    public TextMsg(string sender, string text, List<TextMsg> options = null, TextMsg response = null)
    {
        Sender = sender;
        Text = text;
        Options = options;
        Response = response;
    }

}