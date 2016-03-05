using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SavesGraphicController : MonoBehaviour {

    public static SavesGraphicController instance;
    public GameObject savePrefab;
    private RectTransform rectTrans;
    private List<Salvataggio> salvataggi = new List<Salvataggio>();

	void Start () {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        rectTrans = gameObject.GetComponent<RectTransform>();
        CaricaSalvataggi();
    }

    void OnEnable()
    {
        CaricaSalvataggi();
    }
	
    public void CaricaSalvataggi()
    {
        int[] ns = PlayerPrefsX.GetListaCodiciSalvataggio();
        for (int i = 0; i < ns.Length; i++)
        {
            Salvataggio caricato = PlayerPrefsX.GetSalvataggio(ns[i]);
			if(caricato != null){
	            Debug.Log("Trovato salvataggio con codice " + caricato.Codice);
	            aggiungiSalvataggio(caricato);
			}
        }
    }

	void Update () {
	
	}

    private void OnSalvataggioAdded(Salvataggio salva)
    {
        GameObject go = (GameObject)Instantiate(savePrefab);
        SavesPrefabController spc = go.GetComponent<SavesPrefabController>();
        spc.Init(salva);
        go.GetComponent<RectTransform>().parent = transform;
        go.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        GetComponent<AutomaticVerticalSize>().AdjustSize();
    }

    public void aggiungiSalvataggio(Salvataggio salva)
    {
        if (savePrefab != null)
        {
            if (rectTrans != null)
            {
                if (salva != null)
                {
                    salvataggi.Add(salva);
                    OnSalvataggioAdded(salva);
                }
            }
            else
            {
                Debug.LogError("Questo oggetto non ha il RectTransform, sicuro di non aver sbagliato?");
            }
        }
        else
        {
            Debug.LogError("Devi impostare prima il prefab");
        }
    }
}
