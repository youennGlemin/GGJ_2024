using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{

    public void PlayButtonSound() {
        SoundManager.instance.uiAudioSource.Play();
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}
