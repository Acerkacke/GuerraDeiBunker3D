using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Player {
    
    TilePosition homeTile;
    public TilePosition HomeTile { get { return homeTile; } protected set { if (value != null) { SetHomeTile(value); } } }


    public Player(Tile homeTile = null)
    {
        if (homeTile != null)
        {
            HomeTile = homeTile.TilePosition;
        }
        else
        {
            HomeTile = new TilePosition(UnityEngine.Random.Range(0,20), UnityEngine.Random.Range(0, 20));
        }
    }
    public Player(Player p)
    {
        HomeTile = p.homeTile;
    }

    protected void SetHomeTile(TilePosition newTile)
    {
        if (homeTile != null)
        {
            Tile oldTile = homeTile.Tile;
            oldTile.UnOccupa();
        }
        homeTile = newTile;

        //TODO : Modificare cosa crea, non ho idea come fare ma fallo;
        if (newTile.CanTile())
        {
            newTile.Tile.Occupa(TileBuilding.CreateTileBuilding("Castello"));
        }
        else
        {
            Debug.Log("Guarda che non ho trovato mapController");
        }
    }
}
