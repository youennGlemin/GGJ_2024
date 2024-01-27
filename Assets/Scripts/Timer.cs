using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    [SerializeField]
    private TMP_Text _displayText;

    private float _remainingTime;

    private Coroutine c;

    public void StartTimer(float time) {
        _remainingTime = time;
        c = StartCoroutine(TimerClock());
    }  
    public void StopTimer() {
        StopCoroutine(c);
    }

    private void DisplayTimer() {
        _displayText.text = $"{_remainingTime}";
    }

    private IEnumerator TimerClock() {
        while (_remainingTime > 0) {
            yield return new WaitForSeconds(1f);
            _remainingTime -= 1f;
        }
        GameManager.Instance.TimerEnd();
        StopTimer();
    }
    private void Update() {
        DisplayTimer();
    }
}