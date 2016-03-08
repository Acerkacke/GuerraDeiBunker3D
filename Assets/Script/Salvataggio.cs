using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Salvataggio {

    //Cose della mappa
    private string nome;
    private Data data;
    private int codice;
    private Map map;
    private Player player;

    //Cose del bunker
    private string nomeBunker;
    private BunkerMap bunkerMap;

    //getters

    public Player Player { get { return player; } }
	public Map Map {get{return map;}}
    public string Nome { get { return nome; }}
    public Data Data { get { return data; } }
    public int Codice { get { return codice; } }

    public string NomeBunker { get { return nomeBunker; } }
    public BunkerMap BunkerMap { get { return bunkerMap; } }

    public Salvataggio(string nome, Map m = null,Player p = null, int codice = 0)
    {
        this.nome = nome;
        this.data = new Data();
        if(p != null)
        {
            this.player = new Player(p);
        }
        else
        {
            this.player = new Player();
        }
        if (m != null)
        {
            this.map = new Map(m);
        }
        else
        {
            this.map = new Map();
        }
        if (codice < 1111)
        {
            this.codice = generaCodice();
        }
        nomeBunker = "New Bunker";
        bunkerMap = new BunkerMap();
    }

	public Salvataggio(Salvataggio s){
		this.nome = s.nome;
		this.data = new Data(s.data);
		this.map = new Map (s.map);
		this.codice = s.codice;
        this.player = new Player(s.player);
        this.nomeBunker = s.nomeBunker;
        this.bunkerMap = new BunkerMap(s.bunkerMap);
	}

    public void setBunkerMap(BunkerMap mappa,string nomeBunker)
    {
        this.nomeBunker = nomeBunker;
        this.bunkerMap = mappa;
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
