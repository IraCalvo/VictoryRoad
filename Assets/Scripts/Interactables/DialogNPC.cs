using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public string dialogToSay;

    public void InteractedWith()
    {
       DialogManager.instance.SetDialog(dialogToSay);
    }
}
