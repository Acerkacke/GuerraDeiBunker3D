using UnityEngine;
using System.Collections;

public class PlacingController : MonoBehaviour {

    public static PlacingController Instance;
    private BunkerBuilding costruzioneCorrente;
    public BunkerBuilding CostruzioneCorrente
    {
        get
        {
            return costruzioneCorrente;
        }
        set
        {
            costruzioneCorrente = value;
            OnCostruzioneChanged();
        }
    }
    

	void Start () {
        Instance = this;
	}
	
	void Update () {
	    if(costruzioneCorrente != null)
        {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(BunkerMapController.Instance.Map.getTileAt((int)(hit.point.x+0.5f),(int)(hit.point.z+0.5f)));
                    BunkerMapController.Instance.Map.getTileAt((int)(hit.point.x + 0.5f), (int)(hit.point.z + 0.5f)).Occupa(costruzioneCorrente.BunkerTileBuilding);
                }
            }
        }
	}

    void OnCostruzioneChanged()
    {

    }
}
