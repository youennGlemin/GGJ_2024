using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

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
    private RawImage _videoPlayerImage;
    [SerializeField]
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private VideoPlayer _videoPlayerPrefab;
    [SerializeField]
    private RenderTexture _videoPlayerTexture;
    [SerializeField]
    private AudioSource audioSource;
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
        List<ItemData> itemdatas = new();
        foreach (ItemData itemdata in _itemDatas) {
            itemdatas.Add(itemdata);
        }

        foreach (ItemHolder itemHolder in _itemHolders) {
                ItemData randomItemData = SearchForItemDataTaggedinList(itemHolder.itemPosition, itemdatas);
                itemHolder.Hydrate(randomItemData);
                itemdatas.Remove(randomItemData);
        }
    }

    private ItemData SearchForItemDataTaggedinList(ItemPosition itemPosition,List<ItemData> itemDatas) {

        List<ItemData> itemDatasList = new();
        foreach (ItemData itemdata in _itemDatas) {
            if ((itemPosition & itemdata.itemPosition) == (itemdata.itemPosition)) {
                itemDatasList.Add(itemdata);
            }
        }
        return itemDatasList[Random.Range(0, itemDatasList.Count - 1)];
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
                    _videoPlayer.Prepare();
                    _videoPlayer.clip = _videoClips[2];


                    RenderTexture renderTexture = new RenderTexture(_videoPlayerTexture);
                    _videoPlayer.targetTexture = renderTexture;
                    _videoPlayerImage.texture = renderTexture;
                    _videoPlayer.Play();
                    _videoPlayerImage.color = new Color(1, 1, 1, 1);
                    _winPanel.SetActive(true);
                } else if (_lossCount >= _requiredLoss) {
                    _videoPlayer.Prepare();
                    _videoPlayer.clip = _videoClips[3];

                    RenderTexture renderTexture = new RenderTexture(_videoPlayerTexture);
                    _videoPlayer.targetTexture = renderTexture;
                    _videoPlayerImage.texture = renderTexture;
                    _videoPlayer.Play();
                    _videoPlayerImage.color = new Color(1, 1, 1, 1);
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
        _videoPlayerImage.color = new Color(1,1,1,0);
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
            _videoPlayer.Prepare();
            if (itemData == _selectedItemData) {
                _winCount++;
                _videoPlayer.clip = _videoClips[0];
                _dialogueIndex = 1;
            } else {
                _lossCount++;
                _videoPlayer.clip = _videoClips[1];
                _dialogueIndex = 2;
            }


            RenderTexture renderTexture = new RenderTexture(_videoPlayerTexture);
            _videoPlayer.targetTexture = renderTexture;
            _videoPlayerImage.texture = renderTexture;
            _videoPlayer.Play();
            _videoPlayerImage.color = new Color(1, 1, 1, 1);
        } else {
            DialogueManager.instance.StartDialogue(_dialogues[3]);
        }
        Player.Instance.EnablePlayer(false);
        Player.Instance.ResetPlayer();
        _selectedItemData = null;

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

    public void PlayClip(AudioClip clip){
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        
    }

    public void Pause
}
