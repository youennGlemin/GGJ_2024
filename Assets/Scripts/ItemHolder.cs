using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private PolygonCollider2D _polygonCollider2D;

    public ItemPosition itemPosition;

    public ItemData itemData;

    public void Hydrate(ItemData itemData) {
        this.itemData = itemData;
        _spriteRenderer.sprite = itemData.sprite;
        int shapeCount = itemData.sprite.GetPhysicsShapeCount();
        _polygonCollider2D.pathCount = shapeCount;
        var points = new List<Vector2>(64);
        for (int i = 0; i < shapeCount; i++) {
            itemData.sprite.GetPhysicsShape(i, points);
            _polygonCollider2D.SetPath(i, points);
        }
    }
    public void Disable() {
        itemData = null;
        _spriteRenderer.sprite = null;
    }

    private void Start() {
        Hydrate(itemData);
    }

    private void OnMouseOver() {
        _spriteRenderer.color = new Color(0.7f, 0.7f, 0.7f);
    }
    private void OnMouseExit() {
        _spriteRenderer.color = new Color(1f, 1f, 1f);

    }
}
