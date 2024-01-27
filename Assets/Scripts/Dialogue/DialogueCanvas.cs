using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{

    /// <summary>
    /// Start Write coroutine
    /// </summary>
    public void StartWriting() {
        StartCoroutine(DialogueManager.instance.Write());
    }
}
