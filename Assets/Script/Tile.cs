using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Tile {

    //Posizioni
    int x;
    int y;
    public int X { get { return x; } }
	public int Y { get { return y; } }
    //Mappa
    Map map;
    public Map Map{ get { return map; } }
    //Informazioni
    public enum TileState { Empty, Full}
    TileState stato;
    Action<Tile> OnStateChangedActions;
    public TileState Stato{
        get {
            return stato;
        }
        protected set{
            stato = value;
            OnStateChangedActions(this);
        }
    }
    TileBuilding tileBuilding;
    public TileBuilding TileBuilding
    {
        get {
            return tileBuilding;
        }
    }
    //costruttore
    public Tile(Map m,int x,int y)
    {
        map = m;
        this.x = x;
        this.y = y;
        //Stato = TileState.Empty;
    }

    //altre funzioni
    
    public void Occupa(TileBuilding tileBuilding)
    {
        this.tileBuilding = TileBuilding.PlaceInstance(this,tileBuilding);
        Stato = TileState.Full;
    }
    public void UnOccupa()
    {
        this.tileBuilding = null;
        Stato = TileState.Empty;
    }

    //OnStateChanged
    public void RegisterOnStateChanged(Action<Tile> a)
    {
        OnStateChangedActions += a;
    }
    public void UnRegisterOnStateChanged(Action<Tile> a)
    {
        OnStateChangedActions -= a;
    }
}
