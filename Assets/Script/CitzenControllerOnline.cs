using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CitzenControllerOnline: NetworkBehaviour {

    NavMeshAgent nma;

	void Start () {
        nma = gameObject.GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    //CmdSetCitzenTarget(hit.point);
                    nma.destination = hit.point;
                }
                
            }
        }
	}

    [Command]
    void CmdSetCitzenTarget(Vector3 pos)
    {
        nma.destination = pos;
        Debug.Log("Hey ma allora esisti");
    }
}
