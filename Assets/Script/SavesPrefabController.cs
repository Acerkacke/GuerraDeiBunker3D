using UnityEngine;
using UnityEngine.UI;

public class SavesPrefabController : MonoBehaviour {

    public string objNome = "Nome";
    public string objData = "Data";
    public string objButton = "PlayButton";

    Text nomeLabel;
    Text dataLabel;
    Button playButton;
    Text buttonLabel;

    private Salvataggio salvataggioCorrente;

	void Start () {
        
    }
	
	void Update () {
	
	}

    private void getNeededComponents()
    {
        nomeLabel = transform.FindChild(objNome).GetComponent<Text>();
        dataLabel = transform.FindChild(objData).GetComponent<Text>();
        playButton = transform.FindChild(objButton).GetComponent<Button>();
        buttonLabel = playButton.transform.FindChild("Text").GetComponent<Text>();
    }

    public void Init(Salvataggio salva)
    {
        getNeededComponents();
        //if(nomeLabel != null && dataLabel != null && playButton != null && buttonLabel != null)
        //{
            salvataggioCorrente = salva;
            nomeLabel.text = salva.Nome;
            dataLabel.text = salva.Data.ToString();

            playButton.onClick.AddListener(() => { CaricaLivello(salva, "MapOverViewOffline"); });
        /*}
        else
        {
            throw (new System.Exception("Non ho trovato uno o piu' componenti"));
        }*/
    }

    public void CaricaLivello(Salvataggio salva,string nomeLivello)
    {
        CaricaSuPlayerPrefs(salva);
        Application.LoadLevel(nomeLivello);
    }

    private void CaricaSuPlayerPrefs(Salvataggio salva)
    {
        PlayerPrefs.SetInt("CodiceCorrente",salva.Codice);
    }

}
