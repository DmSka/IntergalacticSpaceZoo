using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMiniGameManager : MonoBehaviour
{
    public GameObject cageMinigame;
    public GameObject cagePrefab;
    public Transform spawnLocation;

    public CargoAreaManager cargoAreaManager;

    public void StartCageMiniGame()
    {
        cageMinigame.GetComponent<CageMiniGame>().Randomize();

        if (GameManager.Instance.cageAmount > 0)
        {
            GameManager.Instance.cageAmount--;
            cageMinigame.SetActive(true);
        }
    }

    public void EndCageMiniGame()
    {
        //play little victory animation


        cageMinigame.SetActive(false);

        //spawn at spawn location
        Instantiate(cagePrefab, spawnLocation);

        CreatureSpawner creatureSpawner = GameObject.Find("CreatureSpawner").GetComponent<CreatureSpawner>();
        creatureSpawner.SpawnCreatureForCrate();

        SpawnInventoryItem();
    }

    public void SpawnInventoryItem()
    {
        cargoAreaManager.SpawnBox();
    }
}
