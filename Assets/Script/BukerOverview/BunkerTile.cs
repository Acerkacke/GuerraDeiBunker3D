using UnityEngine;
using System.Collections;
using System;

public class BunkerTile {

    //Posizioni
    int x;
    int y;
    public int X { get { return x; } }
    public int Y { get { return y; } }

    BunkerMap map;
    public BunkerMap BunkerMap { get { return map; } }

    public enum BunkerTileState { Empty,Full}
    BunkerTileState stato;
    public BunkerTileState Stato
    {
        get
        {
            return stato;
        }
        protected set
        {
            stato = value;
            if (OnStateChangedActions != null)
            {
                Debug.Log("Chiamato OnStateChanged");
                OnStateChangedActions(this);
            }
        }
    }
    Action<BunkerTile> OnStateChangedActions;

    BunkerTileBuilding building;
    public BunkerTileBuilding Building { get { return building; } }

    public BunkerTile(BunkerMap map, int x, int y)
    {
        this.map = map;
        this.x = x;
        this.y = y;
        Stato = BunkerTileState.Empty;
    }

    public BunkerTile(BunkerTile bTile)
    {
        this.map = bTile.map;
        this.x = bTile.x;
        this.y = bTile.y;
        this.Stato = bTile.Stato;
    }

    public void Occupa(BunkerTileBuilding bunkerBuilding)
    {
        if (stato == BunkerTileState.Empty)
        {
            //TODO : Quando hai fatto BunkerTileBuilding torna qua
            //this.building = BunkerTileBuilding.PlaceInstance(this, building);
            Stato = BunkerTileState.Full;
        }
        else {
            Debug.Log("E' gia' occupato (Tile_" + x + "_" + y + ")");
        }
    }
    public void UnOccupa()
    {
        this.building = null;
        Stato = BunkerTileState.Empty;
    }
    public void RegisterOnStateChanged(Action<Tile> a)
    {
        OnStateChangedActions += a;
    }
    public void UnRegisterOnStateChanged(Action<Tile> a)
    {
        OnStateChangedActions -= a;
    }
    public override string ToString()
    {
        return "BunkerTile x:" + x + " y:" + y;
    }
}
