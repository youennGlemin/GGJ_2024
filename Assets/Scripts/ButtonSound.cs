using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    public void PlayButtonSound() {
        SoundManager.instance.uiAudioSource.Play();
    }
    public void QuitGame() {
        Application.Quit();
    }
}
