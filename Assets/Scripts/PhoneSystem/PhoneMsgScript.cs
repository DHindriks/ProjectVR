using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneMsgScript : MonoBehaviour
{
    public TextMsg ContainedMsg;

    [SerializeField]
    TextMeshProUGUI Text;
    public void Settext(string setto)
    {
        Text.text = setto;
    }
}
