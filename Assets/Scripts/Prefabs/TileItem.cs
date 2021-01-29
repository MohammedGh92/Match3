using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class TileItem : MonoBehaviour
{
    [SerializeField]
    private Vector2 tilePos;
    [SerializeField]
    private TileType tileType;
    [SerializeField]
    private SpriteRenderer MySprRenderer;
    private GridManager gridManager;

    private bool Checked;

    public void SetItem(Vector2 tilePos, GridManager gridManager)
    {
        this.gridManager = gridManager;
        SetTileType((TileType)Random.Range(0, 3));
        SetTilePos(tilePos);
    }

    public void OnMouseDown()
    {
        CheckMatch();
    }

    public void CheckMatch()
    {
        gridManager.CheckMatch(this);
    }

    public void SetTileType(TileType tileType)
    {
        MySprRenderer.sprite = gridManager.GetSpriteFromTileType(tileType);
        this.tileType = tileType;
    }

    public TileType GetTileType()
    {
        return tileType;
    }
    public void SetTilePos(Vector2 tilePos)
    {
        int X = (int)tilePos.x;
        int Y = (int)Mathf.Abs(tilePos.y);
        this.tilePos = new Vector2(X, Y);
    }

    public Vector2 GetTilePos()
    {
        return this.tilePos;
    }

    public void Matched()
    {
        gameObject.SetActive(false);
    }

    public void SetChecked(bool Checked) { this.Checked = Checked; }
    public bool GetChecked() { return Checked; }

}