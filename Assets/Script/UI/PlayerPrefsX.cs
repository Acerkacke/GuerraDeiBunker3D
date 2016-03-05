using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerPrefsX
{
    //Setters
    public static void SetInt(string key,int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public static void SetBool(string key,bool value)
    {
        if (value){ PlayerPrefs.SetInt(key, 1);}
        else{ PlayerPrefs.SetInt(key, 0);}
    }
    public static void SetData(string key,Data value)
    {
        PlayerPrefs.SetInt(key + "_G", value.Giorno);
        PlayerPrefs.SetInt(key + "_M", value.Mese);
    }
    public static void SetSalvataggio(Salvataggio salvataggio)
    {
		bool hasToAdd = true;
		salvataggio = new Salvataggio (salvataggio);
		if (File.Exists (Application.persistentDataPath + "/" + salvataggio.Codice + ".dat")) {
			hasToAdd = false;
		}
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + salvataggio.Codice + ".dat");

        bf.Serialize(file,salvataggio);
        file.Close();
        PlayerPrefs.SetInt("Salvataggio" + getNSalvataggi(), salvataggio.Codice);
		if (hasToAdd) {
			SetNSalvataggi ();
		}
        //Debug.Log("Salvato " + salvataggio.Nome + " con codice " + salvataggio.Codice);
        //Debug.Log("Adesso allora ci saranno " + PlayerPrefs.GetInt("NSalva") + " salvataggi, e l'ultimo di essi ha codice " + PlayerPrefs.GetInt("Salvataggio" + (PlayerPrefs.GetInt("NSalva")-1)));
    }
    private static void SetNSalvataggi()
    {
        PlayerPrefs.SetInt("NSalva",PlayerPrefs.GetInt("NSalva")+1);
    }
    

    //Getters
    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    public static bool GetBool(string key)
    {
        int n = PlayerPrefs.GetInt(key);
        if(n == 1)
            return true;
        return false;
    }
    public static Data GetData(string key)
    {
        return new Data(PlayerPrefs.GetInt(key+"_G"),PlayerPrefs.GetInt(key+"_M"));
    }

    public static Salvataggio GetSalvataggio(int codiceSalvataggio)
    {
        if(File.Exists(Application.persistentDataPath + "/" + codiceSalvataggio + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + codiceSalvataggio + ".dat",FileMode.Open);
            Salvataggio s = (Salvataggio)bf.Deserialize(file);
			file.Close();
			//Debug.Log(Application.persistentDataPath + "/" + codiceSalvataggio + ".dat");
			return s;
        }
        else
        {
            return null;
        }
    }
    public static int getNSalvataggi()
    {
        return PlayerPrefs.GetInt("NSalva");
    }
    public static int[] GetListaCodiciSalvataggio()
    {
        int[] codici = new int[PlayerPrefs.GetInt("NSalva")];
        for (int i = 0; i < codici.Length; i++)
        {
			//Debug.Log(PlayerPrefs.GetInt("Salvataggio" + i));
            codici[i] = PlayerPrefs.GetInt("Salvataggio" + i);
        }
        return codici;
    }
}

