using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    [SerializeField]
    private RootController rootController;
    public GameObject TileItemPrefab;
    public Transform GridParentTrans;

    private GridO MyGrid;

    public Sprite RedSpr, GreenSpr, BlueSpr, BlackSpr;

    public void GenerateNewGrid()
    {
        ShowGrid(true);
        MyGrid = new GridO();
        for (int y = 0; y < 9; y++)
            for (int x = 0; x < 9; x++)
            {
                Vector2 TilePos = new Vector2(x, y);
                GameObject TileGO = Instantiate(TileItemPrefab, TilePos, Quaternion.identity, GridParentTrans) as GameObject;
                TileItem CurrentTileItem = TileGO.GetComponent<TileItem>();
                CurrentTileItem.SetItem(TilePos, this);
                MyGrid.SetThisTileItem(TilePos, CurrentTileItem);
            }
        GridParentTrans.position = new Vector2(0, -8);
    }


    [SerializeField]
    private List<TileItem> MatchedList;
    public void CheckMatch(TileItem tileItem)
    {
        if (!IsMatching)
        { MatchedList.Add(tileItem); StartMatching(tileItem); }
    }

    private void StartMatching(TileItem tileItem)
    {
        if (tileItem.GetChecked())
            return;
        List<TileItem> NewMatchedList = MyGrid.GetMatchedTileNaighbours(tileItem);
        tileItem.SetChecked(true);
        for (int i = 0; i < NewMatchedList.Count; i++)
        {
            MatchedList.Add(NewMatchedList[i]);
            StartMatching(NewMatchedList[i]);
        }
        if (!IsMatching)
            StartCoroutine(CheckAfterSecsCor());
    }

    private bool IsMatching;
    private IEnumerator CheckAfterSecsCor()
    {
        IsMatching = true;
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Checking");
        IsMatching = false;
        if (MatchedList.Count > 2)
        {
            for (int i = 0; i < MatchedList.Count; i++)
                MatchedList[i].Matched();
        }
        else
        {
            for (int i = 0; i < MatchedList.Count; i++)
                MatchedList[i].SetChecked(false);
        }
        MatchedList.Clear();

    }

    public Sprite GetSpriteFromTileType(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Red: return RedSpr;
            case TileType.Green: return GreenSpr;
            case TileType.Blue: return BlueSpr;
            default:
                return BlackSpr;
        }
    }

    public void ShowGrid(bool Show) { GridParentTrans.gameObject.SetActive(Show); }

}