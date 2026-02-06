using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoAreaManager : MonoBehaviour
{
    public GameObject BoxPrefab;
    public Transform BoxSpawnLocation;

    public bool CargoActive = false;
    public GameObject Background;

    public GameObject UISwaper;

    public Vector3 cargoUpPosition;
    public Vector3 cargoDownPosition;

    public void SpawnBox()
    {
        GameObject spawnedBox = Instantiate(BoxPrefab, BoxSpawnLocation.position, Quaternion.identity);
        spawnedBox.GetComponentInChildren<SpriteRenderer>().sprite = GameManager.Instance.creatures[^1].sprite;
    }

    public void ToggleCargo()
    {
        CargoActive = !CargoActive;

        Background.SetActive(!CargoActive);
        if (CargoActive)
            UISwaper.transform.localPosition = cargoUpPosition;
        else
            UISwaper.transform.localPosition = cargoDownPosition;
    }
}
