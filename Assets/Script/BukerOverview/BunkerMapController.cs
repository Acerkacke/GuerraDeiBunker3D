using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class BunkerMapController : MonoBehaviour {

    public GameObject tilePrefab;


    string nomeBunker = "Nuovo Bunker";
    BunkerMap map;
    public BunkerMap Map
    {
        get { return map; }
        protected set
        {
            map = value;
            CreaMappa();
        }
    }

    public static BunkerMapController Instance;

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

    Salvataggio currSalvataggio;
    public Salvataggio Salvataggio
    {
        get { return currSalvataggio; }
    }

    void PopulatePrefabsDictionary()
    {
        prefabs.Add("tile", tilePrefab);
        prefabs.Add("Terra", Resources.Load("Prefabs/BloccoDiTerra") as GameObject);
        prefabs.Add("TrePerDue", Resources.Load("Prefabs/3x2") as GameObject);
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        PopulatePrefabsDictionary();

        ControlloSalvataggi();

        Map = new BunkerMap();
    }

    void ControlloSalvataggi()
    {
        Salvataggio s = PlayerPrefsX.GetSalvataggio(PlayerPrefs.GetInt("LastPlayed", 0));

        if (s != null)
        {
            Carica(s);
        }
        else {
            Debug.LogError("Sei arrivato qui senza un salvataggio precedente");
        }
    }


    void Salva(Salvataggio s)
    {
        s.setBunkerMap(map, "nomeBunker");
        PlayerPrefsX.SetSalvataggio(s);
        PlayerPrefs.SetInt("LastPlayed", s.Codice);
    }

    void Carica(Salvataggio s)
    {
        nomeBunker = s.NomeBunker;
        Map = new BunkerMap(s.BunkerMap);
        currSalvataggio = new Salvataggio(s);
    }

    void CreaMappa()
    {
        for (int x = 0; x < map.Larghezza; x++)
        {
            for (int y = 0; y < map.Altezza; y++)
            {
                BunkerTile tile_data = map.getTileAt(x, y);

                GameObject tile_go = Instantiate(tilePrefab);
                tile_go.name = "BunkerTile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(x, 0, y);
                BunkerTileInspector bti = tile_go.AddComponent<BunkerTileInspector>();
                bti.x = x;
                bti.y = y;
                if (tile_data.Stato == BunkerTile.BunkerTileState.Full)
                {
                    OnBunkerTileStateChanged(tile_data, tile_go);
                }

                tile_data.RegisterOnStateChanged((tile) => { tile_go = OnBunkerTileStateChanged(tile, tile_go); });
            }
        }
        map.getTileAt (0, 3).Occupa (BunkerTileBuilding.CreateTileBuilding("TrePerDue",2,3));
        //Debug.Log (map.getTileAt (2, 2).TileBuilding.ToString());
    }

    GameObject OnBunkerTileStateChanged(BunkerTile tile_data, GameObject tile_go)
    {
        string oldname = tile_go.name;
        Vector3 oldPosition = tile_go.transform.position;

        GameObject oldGo = tile_go;
        string objType = null;
        if (tile_data.BunkerBuilding == null)
        {
            objType = "tile";
        }
        else {
            if (tile_data.BunkerBuilding.ObjType != null)
            {
                objType = tile_data.BunkerBuilding.ObjType;
            }
            else
            {
                objType = "tile";
            }
        }
        tile_go = (GameObject)Instantiate(prefabs[objType]);
        tile_go.name = oldname;
        tile_go.transform.position = oldPosition;

        BunkerTileInspector bti = tile_go.AddComponent<BunkerTileInspector>();
        bti.x = tile_data.X;
        bti.y = tile_data.Y;

        Destroy(oldGo);

        return tile_go;

    }
}
