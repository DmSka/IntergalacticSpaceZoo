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
        SpriteRenderer[] renderers = spawnedBox.GetComponentsInChildren<SpriteRenderer>();
        foreach (var r in renderers)
        {
            if (r.gameObject != spawnedBox) // skip the root
            {
                r.sprite = GameManager.Instance.creatures[^1].sprite;
                break; // stop after first child
            }
        }

        // Get the int from another class
        int sizeIncrement = GameManager.Instance.creatures[^1].GetIntFromSize();

        // Scale the whole box: keep current scale, then add a portion of the int
        float portion = 0.1f; // how much each int unit increases scale
        Vector3 newScale = spawnedBox.transform.localScale + Vector3.one * sizeIncrement * portion;
        spawnedBox.transform.localScale = newScale;
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
