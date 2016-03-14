using UnityEngine;
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
        immagini.Clear();
        foreach(string key in dizionario.Keys)
        {
            string chiave = key;
            immagini.Add((GameObject)Instantiate(imagePrefab));
            immagini[i].transform.SetParent(pannello.transform,false);
            immagini[i].name = chiave;
            Image img = immagini[i].GetComponent<Image>();
            img.sprite = dizionario[chiave].Preview;
            Button bottone = immagini[i].GetComponent<Button>();
            Debug.Log("Key : " + chiave);
            bottone.onClick.AddListener(() => { PlacingController.Instance.CostruzioneCorrente = dizionario[chiave]; Debug.Log("Impostato " + chiave); });
            i++;
        }
        RectTransform rt = pannello.GetComponent<RectTransform>();
        Vector2 size = rt.sizeDelta;
        size.y = pannello.transform.childCount * 70;
        Vector2 pos = rt.anchoredPosition;
        pos.y = -65 -(size.y / 2);
        rt.sizeDelta = size;
        rt.anchoredPosition = pos;
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
