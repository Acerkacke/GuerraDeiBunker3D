using UnityEngine;
using System.Collections;

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

    public Map(int larghezza,int altezza)
    {
        this.Altezza = altezza;
        this.Larghezza = larghezza;
        tiles = new Tile[larghezza,altezza];
    }

}
