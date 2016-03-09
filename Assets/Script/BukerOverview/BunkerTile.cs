using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
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
                //Debug.Log("Chiamato OnStateChanged");
                OnStateChangedActions(this);
            }
        }
    }
    Action<BunkerTile> OnStateChangedActions;

    BunkerTileBuilding bunkerBuilding;
    public BunkerTileBuilding BunkerBuilding { get { return bunkerBuilding; } }

    public BunkerTile(BunkerMap map, int x, int y)
    {
        this.map = map;
        this.x = x;
        this.y = y;
        Stato = BunkerTileState.Empty;
        //occupiamola di base con la terra
        //Occupa(BunkerTileBuilding.CreateTileBuilding("Terra"));
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
            this.bunkerBuilding = BunkerTileBuilding.PlaceInstance(this, bunkerBuilding);
            Debug.Log("Adesso sono " + bunkerBuilding);
            Stato = BunkerTileState.Full;
        }
        else {
            Debug.Log("E' gia' occupato (Tile_" + x + "_" + y + ")");
        }
    }

    public void UnOccupa()
    {
        if (bunkerBuilding.OriginTile.Equals(this))
        {
            bunkerBuilding.Sbaracca();
        }
        this.bunkerBuilding = null;
        Stato = BunkerTileState.Empty;
    }
    public void RegisterOnStateChanged(Action<BunkerTile> a)
    {
        OnStateChangedActions += a;
    }
    public void UnRegisterTuttiOnStateChanged()
    {
        OnStateChangedActions = null;
    }
    public override string ToString()
    {
        return "BunkerTile x:" + x + " y:" + y;
    }
}
