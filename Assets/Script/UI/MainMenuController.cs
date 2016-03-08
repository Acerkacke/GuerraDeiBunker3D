using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public GameObject[] pannelli;
    private int currActivePanel = 0;
    public static MainMenuController instance;

	void Start () {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        int pannelloAttivo = findActivePanel();
	    if(pannelloAttivo != -1)
        {
            currActivePanel = pannelloAttivo;
        }
	}

    public int findActivePanel()
    {
        for (int i = 0; i < pannelli.Length; i++)
        {
            if (pannelli[i].activeSelf)
            {
                return i;
            }
        }
        return -1;
    }
	
    public void setPanelActive(int pannello)
    {
        if (pannello >= 0 && pannello < pannelli.Length)
        {
            if (currActivePanel != pannello)
            {
                pannelli[currActivePanel].SetActive(false);
                pannelli[pannello].SetActive(true);
                currActivePanel = pannello;
            }
        }
        else
        {
            Debug.LogError("Non esiste questo pannello, dovresti sistemare qualcosa");
        }
    }

    public void CreaSalvataggio(string nome, int diff = 1)
    {
        Salvataggio salva = new Salvataggio(nome);
        PlayerPrefsX.SetSalvataggio(salva);
        //SavesGraphicController.instance.CaricaSalvataggi(); //volevo aggiornare ma faccio aggiornare ogni volta che viene creato
        Debug.Log("Creato salvataggio");
    }

    public void EliminaTutto()
    {
        PlayerPrefs.DeleteAll();
    }

}
