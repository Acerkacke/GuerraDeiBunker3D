using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Salvataggio {

    private string nome;
    private Data data;
    private int codice;
    private Map map;


    public string Nome { get { return nome; }}
    public Data Data { get { return data; } }
    public int Codice { get { return codice; } }

    public Salvataggio(string nome,int codice = 0)
    {
        this.nome = nome;
        this.data = new Data();
        this.map = MapController.Instance.Map;
        if (codice < 1111)
        {
            this.codice = generaCodice();
        }
    }

    public int generaCodice()
    {
        int cod = Random.Range(1111, 9999);
        while (!CodiceDisponibile(cod))
        {
            cod = Random.Range(1111, 9999);
        }
        updateNCodici();
        return cod;
    }

    private void updateNCodici(int numeroDaSommare = 1)
    {
        PlayerPrefs.SetInt("NCodici", PlayerPrefs.GetInt("NCodici") + numeroDaSommare);
    }

    public static bool CodiceDisponibile(int codice)
    {
        for(int i = 0; i < NCodici(); i++)
        {
            if(codice == PlayerPrefs.GetInt("Codici" + i))
            {
                return false;
            }
        }
        return true;
    }

    public static int NCodici()
    {
        return PlayerPrefs.GetInt("NCodici");
    }
}
