using UnityEngine;
using System.Collections;

[System.Serializable]
public class Data {

    int giorno;
    int mese;
    public int Giorno { get { return giorno; } }
    public int Mese { get { return mese; } }

    public Data(int giorno = 0,int mese = 0)
    {
        if (giorno == 0 || mese == 0)
        {
            this.giorno = System.DateTime.Now.Day;
            this.mese = System.DateTime.Now.Month;
        }
        else
        {
            if (giorno <= 31 && giorno > 0)
            {
                if (mese <= 12 && mese > 0)
                {
                    this.giorno = giorno;
                    this.mese = mese;
                }
                else
                {
                    throw (new System.Exception("IL MESE E' SBAGLIATO"));
                }
            }
            else
            {
                throw (new System.Exception("IL GIORNO E' SBAGLIATO"));
            }
        }
    }

    public string ToString()
    {
        return giorno + "/" + mese;
    }

}
