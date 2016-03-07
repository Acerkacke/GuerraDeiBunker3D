using UnityEngine;
using UnityEditor;
using System.Collections;

public class BunkerTileInspector : MonoBehaviour {
    public int x;
    public int y;

    public BunkerTileInspector(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}

[CustomEditor(typeof(BunkerTileInspector))]
public class BunkerTileInspectorEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        BunkerTileInspector myTarget = (BunkerTileInspector)target;
        BunkerTile tile = BunkerMapController.Instance.Map.getTileAt(myTarget.x, myTarget.y);
        EditorGUILayout.LabelField("Pos : ", "x:" + tile.X + " y:" + tile.Y);
        EditorGUILayout.LabelField("Stato : ", tile.Stato.ToString());
        if(tile.Stato == BunkerTile.BunkerTileState.Full)
        {
            if (GUILayout.Button("Sbaracca"))
            {
                //Debug.Log("Schiacciato sbaracca");
                tile.UnOccupa();
            }
        }
        else
        {
            EditorGUILayout.Space();
            if (GUILayout.Button("Atterra"))
            {
                //Debug.Log("Schiacciato atterra");
                tile.Occupa(BunkerTileBuilding.CreateTileBuilding("Terra"));
            }
        }
    }
}
