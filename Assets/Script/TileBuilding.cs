.using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileBuilding {

    Tile tile;
    public Tile Tile { get { return tile; } }
    string objType;
    public string ObjType { get { return objType; } }
    int width;
    int height;

    protected TileBuilding()
    {

    }
    protected TileBuilding(string objType, int width = 1, int height = 1)
    {
        this.objType = objType;
        this.width = width;
        this.height = height;
    }
    protected TileBuilding(Tile tile, TileBuilding tileBuilding)
    {
        this.objType = tileBuilding.objType;
        this.width = tileBuilding.width;
        this.height = tileBuilding.height;
        this.tile = tile;
    }
    public static TileBuilding CreateTileBuilding(string objType, int width = 1,int height = 1)
    {
        return new TileBuilding(objType,width,height);
    }
    public static TileBuilding PlaceInstance(Tile tile, TileBuilding tileBuilding)
    {
        return new TileBuilding(tile, tileBuilding);
    }
	public string ToString(){
		return objType;
	}
}
