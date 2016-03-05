using UnityEngine;
using System.Collections;

public class OfflinePlayerMapController : MonoBehaviour {

    Player currentPlayer;
    public static OfflinePlayerMapController Instance;

    void Start() {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }
        //carica player
        currentPlayer = MapController.Instance.Salvataggio.Player;

    }
	
	void Update () {
	
	}
}
