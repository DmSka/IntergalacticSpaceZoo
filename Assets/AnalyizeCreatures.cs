using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyizeCreatures : MonoBehaviour
{
    public GameObject prefab;
    public AnalyizeUIManager analyizeUIManager;

    public int creatureIndex = 0;
    //spawn the analysis creature UI

    GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartAnalysis()
    {
        GameObject prefabObj = Instantiate(prefab);
        prefabObj.transform.SetParent(null);

        prefabObj.transform.position = Vector3.zero;
        prefabObj.transform.rotation = Quaternion.identity;
        prefabObj.transform.localScale = Vector3.one;

        analyizeUIManager = prefabObj.GetComponent<AnalyizeUIManager>();
        PopulateUI();
    }

    public void NextCreature()
    {
        if (gameManager.creatures.Count <= creatureIndex++)
            creatureIndex++;
        else creatureIndex = 0;
    }

    public void PreviousCreature()
    {
        if (creatureIndex <= 0)
            creatureIndex = 0;
        else creatureIndex--;
    }

    //populate the image with creature information
    private void PopulateUI()
    {
        analyizeUIManager.Analyize(gameManager.creatures[creatureIndex]);
    }
}
