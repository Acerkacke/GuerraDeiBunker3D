using UnityEngine;
using System.Collections;

[System.Serializable]
public class Map {

    //Matrice di Tiles
    Tile[,] tiles;
    public Tile[,] Tiles { get { return tiles; } }

    //Dimensioni
    int altezza;
    int larghezza;
    public int Altezza{
        get
        {
            return altezza;
        }
        protected set
        {
            altezza = value;
        }
    }
    public int Larghezza
    {
        get
        {
            return larghezza;
        }
        protected set
        {
            larghezza = value;
        }
    }

    public Map(int larghezza = 25,int altezza = 25)
    {
        this.Altezza = altezza;
        this.Larghezza = larghezza;
        tiles = new Tile[larghezza, altezza];
        for (int x = 0; x < larghezza; x++)
        {
            for (int y = 0; y < altezza; y++)
            {
                tiles[x, y] = new Tile(this,x,y);
            }
        }
    }

	public Map(Map m){
		this.Altezza = m.Altezza;
		this.Larghezza = m.Larghezza;
		tiles = new Tile[larghezza, altezza];
		for (int x = 0; x < larghezza; x++)
		{
			for (int y = 0; y < altezza; y++)
			{
				tiles[x, y] = new Tile(this,x,y);
				if(m.tiles[x,y].Stato == Tile.TileState.Full){
					tiles[x,y].Occupa(m.tiles[x,y].TileBuilding);
				}
			}
		}
	}

    public Tile getTileAt(int x,int y)
    {
        return tiles[x, y];
    }

    public override string ToString()
    {
        return "Mappa alt:" + altezza + " larg:" + larghezza;
    }

}
