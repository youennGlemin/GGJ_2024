using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

//public class DialogueCreator : EditorWindow {

//    private string dialogueName;
//    //private Line lineToAdd = new Line("", null, "");
//    private List<Line> dialogueLines = new List<Line>();
//    private List<bool> ShowDialogue = new List<bool>(); 

//    [MenuItem("Tools/Dialogue creator")]
//    public static void ShowWindow() {
//        GetWindow<DialogueCreator>("Dialogue creator");       
//    }
//    private void OnGUI() {

//        dialogueName = EditorGUILayout.TextField("Dialogue name", dialogueName);

//        if(dialogueLines.Count < 1) {
//            dialogueLines.Add(new Line("", null, "",null));
//            ShowDialogue.Add(true);
//        }

//        foreach(Line line in dialogueLines) {
//            DisplayDialogue(line, dialogueLines.IndexOf(line));
//        }


//        EditorGUILayout.Space();
//        if (GUILayout.Button("Create scriptable WeaponData")) {

//            if (dialogueName.Length <= 0) {
//                Debug.LogError("Please enter a name for your dialogue");
//                return;
//            }
//            if (dialogueLines.Count <= 0) {
//                Debug.LogError("Dialogue lines count should be higher than zero");
//                return;
//            }

//            DialogueData dialogueData = (DialogueData)ScriptableObject.CreateInstance("DialogueData");

//            dialogueData.name = dialogueName;
//            dialogueData.lines = dialogueLines.ToArray();

//            AssetDatabase.CreateAsset(dialogueData, "Assets/ScriptableObjects/DialogueData/" + dialogueName + ".asset");

//            dialogueName = "";
//            dialogueLines.Clear();
//        }
//    }

//    private void DisplayDialogue(Line line, int index) {
//        Debug.Log(ShowDialogue[index] + " // " + line.characterName);

//        ShowDialogue[index] = EditorGUILayout.BeginFoldoutHeaderGroup(ShowDialogue[index], line.characterName);
//        if (ShowDialogue[index]) {
//            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
//            EditorGUILayout.BeginVertical();
//            line.characterName = EditorGUILayout.TextField("Character name", line.characterName);
//            line.characterSprite = (Sprite)EditorGUILayout.ObjectField("Character sprite", line.characterSprite, typeof(Sprite), false);
//            line.text = EditorGUILayout.TextField("line text", line.text);

//            Debug.Log(ShowDialogue[index] + " // " + line.characterName);

//            //if (GUILayout.Button("AddLine (Please add the lines in right the order)")) {
//            //    dialogueLines.Add(new Line(line));
//            //    line.characterName = null;
//            //    line.characterSprite = null;
//            //    line.text = "";
//            //}
//            EditorGUILayout.EndVertical();
//            EditorGUILayout.BeginVertical();
//            if (GUILayout.Button("A")) {

//            }
//            if (GUILayout.Button("V")) {

//            }
//            EditorGUILayout.EndVertical();
//            EditorGUILayout.EndHorizontal();
//        }
        
//        EditorGUILayout.EndFoldoutHeaderGroup();
//    }

//    private void DisplayStringList() {
    
//    }
//}
