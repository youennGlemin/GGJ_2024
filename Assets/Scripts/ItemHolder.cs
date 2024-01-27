using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private PolygonCollider2D _polygonCollider2D;

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
}
