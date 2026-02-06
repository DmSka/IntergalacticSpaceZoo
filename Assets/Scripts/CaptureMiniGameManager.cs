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
        cageMinigame.SetActive(true);
    }

    public void EndCageMiniGame()
    {
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
