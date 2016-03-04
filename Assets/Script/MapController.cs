using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

    Map map;
    public Map Map { get { return map; } }
    public GameObject tilePrefab;
    public int altezza = 25;
    public int larghezza = 25;
    public static MapController Instance;

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

    void PopulatePrefabsDictionary()
    {
        prefabs.Add("Castello", Resources.Load("Prefabs/Castello_prefab") as GameObject);
    }

	void Awake () {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        PlayerPrefsX.SetSalvataggio(new Salvataggio("La mamma di nardi"));
        PopulatePrefabsDictionary();
        map = new Map(larghezza,altezza);
        CreaMappa();
    }

    void CreaMappa()
    {
        for(int x = 0; x < map.Larghezza; x++)
        {
            for(int y = 0; y < map.Altezza; y++)
            {
                Tile tile_data = map.getTileAt(x, y);

                GameObject tile_go = Instantiate(tilePrefab);
                tile_go.name = "Tile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(x,0,y);

                tile_data.RegisterOnStateChanged((tile) => { OnTileStateChanged(tile, tile_go); });
            }
        }
    }

    void OnTileStateChanged(Tile tile_data,GameObject tile_go)
    {
        Debug.Log("Cambiato stato, adesso sono un " + tile_data.TileBuilding.ObjType);
        string oldname = tile_go.name;
        Vector3 oldPosition = tile_go.transform.position;
        Destroy(tile_go);
        tile_go = (GameObject)Instantiate(prefabs[tile_data.TileBuilding.ObjType]);
        tile_go.name = oldname;
        tile_go.transform.position = oldPosition;
    }
	
	void Update () {
	
	}
}
