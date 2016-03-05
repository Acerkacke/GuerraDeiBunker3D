using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreaSalvataggioButtonController : MonoBehaviour {

    string nomeSalvataggio;

	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => { if (nomeSalvataggio != null && nomeSalvataggio != "" && nomeSalvataggio != " ") { MainMenuController.instance.CreaSalvataggio(nomeSalvataggio); MainMenuController.instance.setPanelActive(1); } else { Debug.Log("Non hai messo nessun nome"); } });
	}

    public void _SetNomeSalvataggio(string nome)
    {
        nomeSalvataggio = nome;
    }
}
