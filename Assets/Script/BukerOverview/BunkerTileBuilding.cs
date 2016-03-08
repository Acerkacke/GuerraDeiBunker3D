using UnityEngine;
using System.Collections;


[System.Serializable]
public class BunkerTileBuilding {
    
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
    protected BunkerTileBuilding(string objType, int width = 1, int height = 1)
    {
        this.objType = objType;
        this.width = width;
        this.height = height;
    }
    protected BunkerTileBuilding(BunkerTile originTile, BunkerTileBuilding tileBuilding)
    {
        this.objType = tileBuilding.objType;
        this.width = tileBuilding.width;
        this.height = tileBuilding.height;
        this.originTile = originTile;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x != 0 || y != 0)
                {
                    BunkerMapController.Instance.Map.getTileAt(x + originTile.X, y + OriginTile.Y).Occupa(CreateTileBuilding("tile"));
                    Debug.Log("Ho occupato " + (x + originTile.X) + " - " + (y + OriginTile.Y));
                }
            }
        }
    }
    public static BunkerTileBuilding CreateTileBuilding(string objType, int width = 1, int height = 1)
    {
        return new BunkerTileBuilding(objType, width, height);
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
