using UnityEngine;
using System.Collections;


[System.Serializable]
public class BunkerTileBuilding {

    private Prodotto prodotto;
    public Prodotto Prodotto { get { return prodotto; } }
    BunkerTile originTile;
    public BunkerTile OriginTile { get { return originTile; } }
    string objType;
    public string ObjType { get { return objType; } }
    int width;
    public int Width {get { return width; } }
    int height;
    public int Height { get { return height; } }

    protected BunkerTileBuilding()
    {

    }
    protected BunkerTileBuilding(string objType,Prodotto prodotto, int width = 1, int height = 1)
    {
        this.objType = objType;
        this.width = width;
        this.height = height;
        this.prodotto = prodotto;
    }
    protected BunkerTileBuilding(BunkerTile originTile, BunkerTileBuilding tileBuilding)
    {
        this.objType = tileBuilding.objType;
        this.width = tileBuilding.width;
        this.height = tileBuilding.height;
        this.originTile = originTile;
        this.prodotto = tileBuilding.prodotto;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x != 0 || y != 0)
                {
                    BunkerMapController.Instance.Map.getTileAt(x + originTile.X, y + OriginTile.Y).Occupa(CreateTileBuilding("tile",Prodotto.Null,1,1));
                    Debug.Log("Ho occupato perche' sono piu grande di 1 :" + (x + originTile.X) + " - " + (y + OriginTile.Y) + " per riempire l'oggetto più grande di uno");
                }
            }
        }
    }
    public static BunkerTileBuilding CreateTileBuilding(string objType,Prodotto prod, int width = 1, int height = 1)
    {
        return new BunkerTileBuilding(objType,prod, width, height);
    }
    public static BunkerTileBuilding PlaceInstance(BunkerTile originTile, BunkerTileBuilding tileBuilding)
    {
            return new BunkerTileBuilding(originTile, tileBuilding);
    }
    public void Sbaracca()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x != 0 || y != 0)
                {
                    Debug.Log("Svuoto " + (x + originTile.X) + " - " + (y + OriginTile.Y));
                    BunkerMapController.Instance.Map.getTileAt(x + originTile.X, y + OriginTile.Y).UnOccupa();
                    
                }
            }
        }
    }

    public static int getOriginTileIndex(BunkerTile[] tiles)
    {
        if (tiles.Length > 0)
        {
            int minTile = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].X < tiles[minTile].X || tiles[i].Y < tiles[minTile].Y)
                {
                    minTile = i;
                }
            }
            return minTile;
        }
        else
        {
            return -1;
        }
    }

    public override string ToString()
    {
        return objType;
    }
}

public enum Prodotto
{
    Null,
    Energia,
    Acqua,
    Ossigeno,

}