using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    public void ClearMessage()
    {
        messageText.text = "";
    }

    public IEnumerator ShowMessageForSeconds(string message, float seconds)
    {
        ShowMessage(message);
        yield return new WaitForSeconds(seconds);
        ClearMessage();
    }
}