using UnityEngine;
using System.Collections;

public class CitzenController : MonoBehaviour {

    NavMeshAgent nma;

	void Start () {
        nma = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                nma.destination = hit.point;
            }

        }
    }
}
