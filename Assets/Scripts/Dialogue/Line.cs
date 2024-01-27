using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line 
{
    [Header("Character")]
    public string characterName;
    public Sprite characterSprite;
    [Space]
    public string text;
    public AudioClip audioClip;
    //public List<string> textList;

    public Line(string characterName, Sprite characterSprite, string text, AudioClip audioClip) {
        this.characterName = characterName;
        this.characterSprite = characterSprite;
        this.text = text;
        this.audioClip = audioClip;
        //this.textList = textList;
    } public Line(string characterName,  string text, AudioClip audioClip) {
        this.characterName = characterName;
        this.characterSprite = null;
        this.text = text;
        this.audioClip = audioClip;
        //this.textList = textList;
    }
    public Line(Line line) {
        this.characterName = line.characterName;
        this.characterSprite = line.characterSprite;
        this.text = line.text;
        this.audioClip = line.audioClip;
        //this.textList = line.textList;
    }
}
