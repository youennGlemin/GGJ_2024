using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

enum GameState {Start,Presentation,Search,Results}
public class GameManager : MonoBehaviour
{

    #region singleton
    private static GameManager _instance = null;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }
    #endregion

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _losePanel;
    [SerializeField]
    private List<ItemHolder> _itemHolders = new();
    [SerializeField]
    private List<ItemData> _itemDatas = new();
    [SerializeField]
    private List<DialogueData> _dialogues= new();
    [SerializeField]
    private string _preItemPresentationText;
    [SerializeField]
    private string _postItemPresentationText;
    [SerializeField]
    private VideoPlayer _videoPlayer;

    [SerializeField]
    private List<VideoClip> _videoClips = new();


    private ItemData _selectedItemData;

    [SerializeField]
    private int _requiredWins;
    private int _winCount;
    [SerializeField]
    private int _requiredLoss;
    private int _lossCount;

    [SerializeField]
    private Timer _timer;
    [SerializeField]
    private float _allowedTime;

    private GameState _gameState = GameState.Start;
    private void PrepareGame() {
        SpawnItems();
        SelectItemData();
    }
    private void SpawnItems() {
        List<ItemData> itemDatas = new();
        foreach(ItemData itemData in _itemDatas) {
            itemDatas.Add(itemData);
        }
        foreach(ItemHolder itemHolder in _itemHolders) {
            ItemData randomItemData = itemDatas[Random.Range(0, itemDatas.Count - 1)];
            itemHolder.Hydrate(randomItemData);
            itemDatas.Remove(randomItemData);
        }
    }

    private void SelectItemData() {
        _selectedItemData = _itemHolders[Random.Range(0, _itemHolders.Count - 1)].itemData;
    }

    public void OnDialogueEnd() {

        Player.Instance.EnablePlayer(true);
        switch (_gameState) {
            case GameState.Start:
                PrepareGame();
                StartItemPresentation();
                break;
            case GameState.Presentation:
                StartGame();
                break;
            case GameState.Search:
                break;
            case GameState.Results:
                if (_winCount >= _requiredWins) {
                    _winPanel.SetActive(true);
                } else if (_lossCount >= _requiredLoss) {
                    _losePanel.SetActive(true);
                } else {
                    ResetGame();
                }
                break;
            default:
                break;
        }
    }
    private int _dialogueIndex;
    private void OnVideoEnd() {
        DialogueManager.instance.StartDialogue(_dialogues[_dialogueIndex]);
    }

    private void StartItemPresentation() {

        _gameState = GameState.Presentation;
        Player.Instance.EnablePlayer(false);
        DialogueData dialogueData = ScriptableObject.CreateInstance<DialogueData>();
        Line line = new Line("Mom", _preItemPresentationText + _selectedItemData.description + _postItemPresentationText, null);
        dialogueData.lines = new Line[] { line };
        DialogueManager.instance.StartDialogue(dialogueData);
    }

    private void StartGame() {
        _gameState = GameState.Search;
        _timer.StartTimer(_allowedTime);
    }
    public void VerifyItem(ItemData itemData) {
        _timer.StopTimer();
        _gameState = GameState.Results;
        if (itemData) {
            if(itemData == _selectedItemData) {
                _winCount++;
                _videoPlayer.clip = _videoClips[0];
                _dialogueIndex = 1;
            } else {
                _lossCount++;
                _videoPlayer.clip = _videoClips[1];
                _dialogueIndex = 2;
            }
            _videoPlayer.Play();
        } else {
            DialogueManager.instance.StartDialogue(_dialogues[3]);
        }
        Player.Instance.EnablePlayer(false);
       
    }

    public void TimerEnd() {
        if(_gameState == GameState.Search) {
            _gameState = GameState.Results;
            Player.Instance.EnablePlayer(false);
            DialogueManager.instance.StartDialogue(_dialogues[4]);
        }
    }

    public void ResetGame() {
        Player.Instance.ResetPlayer();
        _selectedItemData = null; 
        PrepareGame();
        StartItemPresentation();
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start() {
        _videoPlayer.loopPointReached += ctx => OnVideoEnd();
        
        Player.Instance.EnablePlayer(false);
        DialogueManager.instance.StartDialogue(_dialogues[0]);
    }
}
