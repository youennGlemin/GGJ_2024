using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour {
    #region Singleton Pattern
    private static DialogueManager _instance = null;

    public static DialogueManager instance {
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
    }
    #endregion

    [Header("Characters SpriteRenderer")]
    [SerializeField]
    private Image CharacterSpriteRenderer;
    [Space]
    [Header("Dialogue text field")]
    [SerializeField]
    private TMP_Text speakingCharacterNameText;
    [SerializeField]
    private TMP_Text speakingCharacterLineText;

    [Space]
    [SerializeField]
    private GameObject dialogueCanvas;

    #region DialogueSystem
    [Space]
    [Header("Writting settings")]
    [SerializeField]
    private float basicInterval;
    [SerializeField]
    private float dotInterval;
    [SerializeField]
    private float commaInterval;
    [SerializeField]
    private float RushIntervalMultiplicator;

    [Space]
    [Header("Audio")]
    [SerializeField]
    private AudioSource audioSource;
    private float interval {
        get {
            switch (toWrite[currentLetter - 1]) {
                case ',':
                    return commaInterval;
                case '.':
                    return dotInterval;
                default:
                    return basicInterval;
            }
        }
    }
    private bool shouldRush;

    private DialogueData _currentDialogueData;
    private DialogueData currentDialogueData {
        get => _currentDialogueData;
        set {
            _currentDialogueData = value;
            toWrite = _currentDialogueData.lines[currentLineIndex].text;
            DisplayCharacters();
            audioSource.Stop();
            audioSource.clip = _currentDialogueData.lines[currentLineIndex].audioClip;
        }
    }
    private int currentLineIndex = 0;
    private int _currentLetter;
    private int currentLetter {
        get => _currentLetter;
        set {
            _currentLetter = value;
            speakingCharacterLineText.text = toWrite.Substring(0, currentLetter);
        }
    }
    private string toWrite = "test aux stérones. Le savoir faire des nouveaux, des anciens, mais aussi des très anciens";

    private bool lineWrote = false;

    /// <summary>
    /// Set up dialogue box and begin writing
    /// </summary>
    /// <param name="dialogueData"> Datas about the dialogue to display</param>
    public void StartDialogue(DialogueData dialogueData) { 
        dialogueCanvas.SetActive(true);
        currentDialogueData = dialogueData;
        audioSource.Play();

        StartCoroutine(Write());
    }

    /// <summary>
    /// Reset dialogue box and hide it
    /// </summary>
    public void StopDialogue() {
        currentLineIndex = 0;
        lineWrote = false;
        shouldRush = false;
        speakingCharacterLineText.text = "";
        dialogueCanvas.SetActive(false);

        GameManager.Instance.OnDialogueEnd();
    }

    /// <summary>
    /// Display the characters on screen
    /// </summary>
    private void DisplayCharacters() {
        //CharacterSpriteRenderer.sprite = currentDialogueData.lines[currentLineIndex].characterSprite;
        speakingCharacterNameText.text = currentDialogueData.lines[currentLineIndex].characterName;
        audioSource.Play();

    }

    /// <summary>
    /// Goes to the next Line => may be updated to add multi texts per characters
    /// </summary>
    private void ContinueDialogue() {
        currentLineIndex++;
        toWrite = _currentDialogueData.lines[currentLineIndex].text;
        shouldRush = false;
        lineWrote = false;
        DisplayCharacters();
        StartCoroutine(Write());
    }

    /// <summary>
    /// Accelerate dialogue writing and continue/stop dialogue once writing is finished
    /// </summary>
    public void SkipButtonPressed() {
        if (!lineWrote) {
            shouldRush = true;
            return;
        }
        if (currentDialogueData.lines.Length > currentLineIndex + 1) {
            ContinueDialogue();
        } else {
            StopDialogue();
        }

    }

    /// <summary>
    /// Write the toWrite string on screen
    /// </summary>
    /// <returns></returns>
    public IEnumerator Write() {
        //if()
        currentLetter = 0;
        while (toWrite.Length > currentLetter) {
            currentLetter++;
            yield return new WaitForSeconds((shouldRush) ? interval * RushIntervalMultiplicator : interval);
        }
        lineWrote = true;
        yield break;
    }
    #endregion

}
