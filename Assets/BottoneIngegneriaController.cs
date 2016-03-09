﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BottoneIngegneriaController : MonoBehaviour {

    public GameObject imagePrefab;
    public GameObject pannello;
    Dictionary<string, BunkerBuilding> dizionario;
    bool eAperto = false;
    private List<GameObject> immagini = new List<GameObject>();

	void Start () {
        dizionario = BunkerMapController.Instance.prefabs;
	}
	
    public void Apri()
    {
        eAperto = !eAperto;
        if (eAperto)
        {
            disegnaCostruzioni();
        }
        else
        {
            eliminaDisegni();
        }
        pannello.SetActive(eAperto);
    }

    public void disegnaCostruzioni()
    {
        int i = 0;
        foreach(string key in dizionario.Keys)
        {
            immagini.Add((GameObject)Instantiate(imagePrefab));
            immagini[i].transform.SetParent(pannello.transform,false);
            immagini[i].name = key;
            Image img = immagini[i].GetComponent<Image>();
            img.sprite = dizionario[key].Preview;
            i++;
        }
    }

    public void eliminaDisegni()
    {
        foreach(GameObject go in immagini)
        {
            Destroy(go);
        }
        immagini.Clear();
    }
	
}
