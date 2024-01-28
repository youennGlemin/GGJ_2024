using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionStyle {
    linear
}
public class SoundManager : MonoBehaviour
{
    #region Singleton Pattern
    private static SoundManager _instance = null;

    public static SoundManager instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    [Header("Music")]
    public AudioSource musicAudioSource;
    [Header("UISounds")]
    public AudioSource uiAudioSource;

    #region ChangeSound Method
    public IEnumerator ChangeSound(AudioSource audioSource,AudioClip audioClip,float transitionTime = 1,TransitionStyle transitionStyle = TransitionStyle.linear) {
        switch (transitionStyle) {

            case TransitionStyle.linear:

                //float defaultVolume = audioSource.volume;
                float percentage = 0;

                if (audioSource.clip != null) {
                    while (audioSource.volume > 0) {
                        Debug.Log(percentage);
                        audioSource.volume = Mathf.Lerp(1, 0, percentage);
                        percentage += Time.deltaTime / transitionTime;
                        yield return null;

                    }
                } else {
                    audioSource.volume = 0;
                }
                
                audioSource.clip = audioClip;
                audioSource.Play();

                percentage = 0f;

                while (audioSource.volume < 1) {
                    Debug.Log(percentage);
                    audioSource.volume = Mathf.Lerp(0, 1, percentage);
                    percentage += Time.deltaTime / transitionTime;
                    yield return null;
                }
                // test hors d'une transition de scène
                // debug volume while
                // fonction pour manipuler le son -> remplacer les while
                break;
        }
    }
    #endregion

    /// <summary>
    /// Change Volume of an audio source
    /// </summary>
    /// <param name="audioSource"> Audio source that will get is volume changed</param>
    /// <param name="volume"> Volume aimed</param>
    /// <param name="transitionTime"> Time the volume will take to go to volume</param>
    /// <param name="transitionStyle"> Type of transition</param>
    public void ChangeVolume(AudioSource audioSource, float volume, float transitionTime = 1,TransitionStyle transitionStyle = TransitionStyle.linear) {
        if(audioSource.volume == volume) {
            return;            
        }

        float percentage = 0;

        float currentVolume = audioSource.volume;

        if(audioSource.volume < volume) {
            while (audioSource.volume < volume) {
                Debug.Log(percentage);
                audioSource.volume = Mathf.Lerp(currentVolume, volume, percentage);
                percentage += Time.deltaTime / transitionTime;
            }
        } 
        else {
            while (audioSource.volume > volume) {
                Debug.Log(percentage);

                audioSource.volume = Mathf.Lerp(volume, currentVolume, percentage);
                percentage += Time.deltaTime / transitionTime;
            }
        }
    }
}
