using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public TextMeshProUGUI dialog;
    public Image dialogBox;
    private Coroutine typingDialog;
    public bool currentlyTypingDialog;
    private string dialogToType;
    private float textSpeed = 0.05f;
    bool textDone = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (dialogBox.gameObject.activeInHierarchy == true)
        {
            PlayerMovement.instance.playerCanMove = false;
        }
        //if (dialogBox.gameObject.activeInHierarchy == false && MenuOptionManager.Instance.UIMenu.gameObject.activeInHierarchy == false)
        //{
        //    PlayerMovement.instance.playerCanMove = true;
        //}

    }

    public bool SetDialog(string textToDialog)
    {
        if (textDone == false)
        {
            if (currentlyTypingDialog)
            {
                dialog.text = dialogToType;
                StopAllCoroutines();
                currentlyTypingDialog = false;
                return false;
            }
            else
            {
                dialog.text = null;
                dialog.text = textToDialog;
                dialogToType = textToDialog;
                dialogBox.gameObject.SetActive(true);
                typingDialog = StartCoroutine(typeDialog(dialog.text));
                return true;
            }
        }
        else
        {
            dialogBox.gameObject.SetActive(false);
            PlayerMovement.instance.playerCanMove = true;
            return true;
        }

    }

    IEnumerator typeDialog(string sentence)
    {
        currentlyTypingDialog = true;
        dialog.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialog.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        currentlyTypingDialog = false;
        textDone = true;
    }
}
