using UnityEngine;
using System.Collections;

[System.Serializable]
public class TilePosition {

    int x;
    int y;

    public int X { get { return x; } }
    public int Y { get { return y; } }
    public Tile Tile {
        get { return _GetTile(); }
    }

    public TilePosition(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    private Tile _GetTile()
    {
        return MapController.Instance.Map.getTileAt(x, y);
    }
    public bool CanTile()
    {
        if(MapController.Instance != null)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Pos x:" + x + " y:" + y;
    }
}
