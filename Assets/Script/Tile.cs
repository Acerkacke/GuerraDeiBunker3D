using UnityEngine;
using System.Collections;

public class Tile {

    //Posizioni
    int x;
    int y;
    public int X { get { return x; } }
    public int Y { get { return y; } }
    //Mappa
    Map map;
    public Map Map{ get { return map; } }
    //costruttore
    public Tile(Map m,int x,int y)
    {
        map = m;
        this.x = x;
        this.y = y;
    }

}
