using UnityEngine;
using System.Collections;

public class BunkerBuilding {

    private GameObject gameObject;
    private Sprite preview;
    private BunkerTileBuilding bunkerTileBuilding;

    public GameObject GameObject { get { return gameObject; } }
    public Sprite Preview { get { return preview; } }
    public BunkerTileBuilding BunkerTileBuilding { get { return bunkerTileBuilding; } }

    public BunkerBuilding(GameObject gameObject,Sprite preview,BunkerTileBuilding bunkerTileBuilding)
    {
        this.gameObject = gameObject;
        this.preview = preview;
        this.bunkerTileBuilding = bunkerTileBuilding;
    }
}
