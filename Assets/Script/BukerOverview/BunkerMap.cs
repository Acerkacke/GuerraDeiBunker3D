using UnityEngine;
using System.Collections;

public class BunkerMap : MonoBehaviour {
    //Matrice di Tiles
    BunkerTile[,] tiles;
    public BunkerTile[,] Tiles { get { return tiles; } }

    //Dimensioni
    int altezza;
    int larghezza;
    public int Altezza
    {
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

    public BunkerMap(int larghezza = 20, int altezza = 20)
    {
        this.Altezza = altezza;
        this.Larghezza = larghezza;
        tiles = new BunkerTile[larghezza, altezza];
        for (int x = 0; x < larghezza; x++)
        {
            for (int y = 0; y < altezza; y++)
            {
                tiles[x, y] = new BunkerTile(this, x, y);
            }
        }
    }

    public BunkerMap(BunkerMap m)
    {
        this.Altezza = m.Altezza;
        this.Larghezza = m.Larghezza;
        tiles = new BunkerTile[larghezza, altezza];
        for (int x = 0; x < larghezza; x++)
        {
            for (int y = 0; y < altezza; y++)
            {
                tiles[x, y] = new BunkerTile(this, x, y);
                if (m.tiles[x, y].Stato == BunkerTile.BunkerTileState.Full)
                {
                    tiles[x, y].Occupa(m.tiles[x, y].BunkerBuilding);
                }
            }
        }
    }

    public BunkerTile getTileAt(int x, int y)
    {
        return tiles[x, y];
    }

    public override string ToString()
    {
        return "Mappa alt:" + altezza + " larg:" + larghezza;
    }
}
