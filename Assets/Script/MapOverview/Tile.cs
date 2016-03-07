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
    public TileState Stato{
        get {
            return stato;
        }
        protected set{
            stato = value;
			if(OnStateChangedActions != null){
				Debug.Log("Chiamato OnStateChanged");
            	OnStateChangedActions(this);
			}
        }
    }
    Action<Tile> OnStateChangedActions;
    //buildings
    TileBuilding tileBuilding;
    public TileBuilding TileBuilding
    {
        get {
            return tileBuilding;
        }
    }
    //TilePosition
    public TilePosition TilePosition
    {
        get { return ToTilePosition(); }
    }

    //costruttore
    public Tile(Map m,int x,int y)
    {
        map = m;
        this.x = x;
        this.y = y;
        Stato = TileState.Empty;
    }

	public Tile(Tile tile){
		this.x = tile.x;
		this.y = tile.y;
		if (tile.stato == TileState.Full) {
			Occupa(tile.tileBuilding);
		} else {
			stato = TileState.Empty;
		}
	}

    //altre funzioni
    
    public void Occupa(TileBuilding tileBuilding)
    {
		if (stato == TileState.Empty) {
			this.tileBuilding = TileBuilding.PlaceInstance (this, tileBuilding);
			Stato = TileState.Full;
		} else {
			Debug.Log("E' gia' occupato (Tile_" + x + "_" + y + ")");
		}
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
    public void UnRegisterTuttiOnStateChanged()
    {
        OnStateChangedActions = null;
    }
    protected TilePosition ToTilePosition()
    {
        return new TilePosition(x,y);
    }
    public override string ToString()
    {
        return "Tile x:" + x + " y:" + y;
    }
}
