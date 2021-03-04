using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRGUI : MonoBehaviour
{
    // UI ELEMENTS
    public Text text;
    public Button test;
    public Button resetPuzzle;

    // RESET MODEL
    public GameObject model;
    private Vector3 posModel;


    // RESET PUZZLE
    public GameObject puzzle;
    private List<GameObject> puzzlePieces = new List<GameObject>();
    private List<Vector3> pos = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        // RESET PUZZLE INI
        GameObject originalGameObject = puzzle;
        for (int i = 0; i < originalGameObject.transform.childCount; i++)
        {
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;
            puzzlePieces.Add(child);
            pos.Add(child.transform.position);
        }

        // RESET MODEL INI
        posModel = model.transform.position;

        // LISTENERS
        resetPuzzle.onClick.AddListener(() => {
            int i = 0;
            foreach(GameObject p in puzzlePieces)
            {
                p.transform.position = pos[i];
                i++;
            }
        });
        test.onClick.AddListener(()=>{
            model.transform.position = posModel;
        });
    }

}
