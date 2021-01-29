using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridO : MonoBehaviour
{

    public TileItem[,] tileItems;

    public GridO()
    {
        tileItems = new TileItem[9, 9];
    }

    public void SetThisTileItem(Vector2 TilePos, TileItem tileItem)
    {
        int X = (int)TilePos.x;
        int Y = (int)TilePos.y;
        tileItems[X, Y] = tileItem;
    }

    public void SetTileType(Vector2 TilePos, TileType NewType)
    {
        tileItems[(int)TilePos.x, (int)TilePos.y].SetTileType(NewType);
    }

    public List<TileItem> GetTileNaighbours(TileItem tileItem)
    {

        List<TileItem> ReturnedList = new List<TileItem>();
        int X = (int)tileItem.GetTilePos().x;
        int Y = (int)tileItem.GetTilePos().y;

        //Get the right square

        if (X <= 7)
        {
            //right
            ReturnedList.Add(tileItems[X + 1, Y]);
        }

        //Get the left square

        if (X >= 1)
        {
            //left
            ReturnedList.Add(tileItems[X - 1, Y]);
        }

        //Get the up and down square
        {
            //upper
            if (Y >= 1) ReturnedList.Add(tileItems[X, Y - 1]);
            //lower
            if (Y <= 7) ReturnedList.Add(tileItems[X, Y + 1]);
        }
        return ReturnedList;
    }


    public List<TileItem> GetMatchedTileNaighbours(TileItem tileItem)
    {

        List<TileItem> ReturnedList = new List<TileItem>();
        int X = (int)tileItem.GetTilePos().x;
        int Y = (int)tileItem.GetTilePos().y;
        if (X <= 7 && !tileItems[X + 1, Y].GetChecked() && tileItems[X + 1, Y].GetTileType() == tileItem.GetTileType()) ReturnedList.Add(tileItems[X + 1, Y]);
        if (X >= 1 && !tileItems[X - 1, Y].GetChecked() && tileItems[X - 1, Y].GetTileType() == tileItem.GetTileType()) ReturnedList.Add(tileItems[X - 1, Y]);
        if (Y >= 1 && !tileItems[X, Y - 1].GetChecked() && tileItems[X, Y - 1].GetTileType() == tileItem.GetTileType()) ReturnedList.Add(tileItems[X, Y - 1]);
        if (Y <= 7 && !tileItems[X, Y + 1].GetChecked() && tileItems[X, Y + 1].GetTileType() == tileItem.GetTileType()) ReturnedList.Add(tileItems[X, Y + 1]);
        return ReturnedList;
    }

    public void GetTileType(int X, int Y)
    {
        tileItems[X, Y].GetTileType();
    }

}