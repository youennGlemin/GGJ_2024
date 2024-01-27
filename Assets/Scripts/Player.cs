using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region singleton
    private static Player _instance = null;
    public static Player Instance {
        get {
            return _instance;
        }
    }
    #endregion

    private Controls _controls;
    private void Awake() {
        _controls = new();
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    private void Start() {
        _initialPos = transform.position;
        _controls.controls_proto.LMB.performed += ctx => OnInteract();
    }
    private void OnEnable() {
        _controls.Enable();
    }
    private void OnDisable() {
        _controls.Disable();
    }



    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Image _holdItemImage;
    [SerializeField]
    private LayerMask _interactableLayer;

    private float _direction;

    private ItemData _holdItemData;

    private Vector3 _initialPos;
    private void Move() {
        Vector2 movementDir;


        movementDir = new Vector2(_direction * _moveSpeed, _rb.velocity.y);

        _rb.velocity = (movementDir);


        if (_rb.velocity.x != 0) {
            FlipCharacter(_rb.velocity.x > 0);
        }
        _animator.SetBool("Run", (_rb.velocity.x != 0));
    }

    private void FlipCharacter(bool b) {
        Vector3 newScale = new Vector3(b ? 1 : -1, 1, 1);

        transform.localScale = newScale;
    }

    private void OnInteract() {
        RaycastHit2D _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_controls.controls_proto.MousePos.ReadValue<Vector2>()), Vector2.zero, _interactableLayer);
        if (!_hit) return;

        if (_hit.collider.gameObject.TryGetComponent(out ItemHolder item)) {
            CollectItem(item);
        }
        else if(_hit.collider.gameObject.TryGetComponent(out Interactable interactable)) {
            interactable.Interact();
        }else {
            GameManager.Instance.VerifyItem(_holdItemData);
        }
    }

    private void CollectItem(ItemHolder item) {
        _holdItemData = item.itemData;
        _holdItemImage.sprite = _holdItemData.sprite;
        _holdItemImage.color = new Color(1,1,1,1);
        item.Disable();
    }

    public void ResetPlayer() {
        Player.Instance.EnablePlayer(false);
        transform.position = _initialPos;
        _holdItemImage.color = new Color(1, 1, 1, 0);
        _holdItemData = null;

    }

    public void EnablePlayer(bool enable) {
        if (enable) {
            _controls.Enable();
        } else {
            _controls.Disable();
            _rb.velocity = Vector2.zero;
        }
    }

    private void Update() {
        _direction = _controls.controls_proto.Direction.ReadValue<float>();
    }
    private void FixedUpdate() {
        Move();       
    }
}
