using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public GameObject[] pannelli;
    private int currActivePanel = 0;

	void Start () {
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

}
