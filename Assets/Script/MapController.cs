using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    Map map;
    public GameObject tilePrefab;
    public int altezza = 25;
    public int larghezza = 25;
	void Start () {
        map = new Map(larghezza,altezza);
        CreaMappa();
    }

    void CreaMappa()
    {
        for(int x = 0; x < map.Larghezza; x++)
        {
            for(int y = 0; y < map.Altezza; y++)
            {
                GameObject tileGO = Instantiate(tilePrefab);
                tileGO.name = "Tile_" + x + "_" + y;
                tileGO.transform.position = new Vector3(x,0,y);
            }
        }
    }
	
	void Update () {
	
	}
}
