using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text messageText;
    [SerializeField] private TMP_Text _infoText;
    private Coroutine messageCoroutine;

    private void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); 
        }
    }

    public void ShowMessage(string message)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }
        messageCoroutine = StartCoroutine(DisplayMessage(message));
    }

    public void ShowInfoMessage(string message, float time=12f) 
    {
        if (messageCoroutine != null) { StopCoroutine(messageCoroutine); }
        messageCoroutine = StartCoroutine(DisplayInfoMessage(message, time));
    }

    private IEnumerator DisplayInfoMessage(string message, float time)
    {
        if (_infoText != null)
        {
            _infoText.text = message;
            _infoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            _infoText.gameObject.SetActive(false);
        }
    }

    private IEnumerator DisplayMessage(string message, float time = 2f)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            yield return new WaitForSeconds(time); 
            messageText.gameObject.SetActive(false);
        }
    }
}
