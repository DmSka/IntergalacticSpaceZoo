using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HabitatUIManager : MonoBehaviour
{
    public Transform[] iconSpawnLocations;
    private List<GameObject> icons = new();
    public GameObject iconPrefab;

    public TextMeshProUGUI money;
    public Habitat habitat;

    public void Start()
    {
        SpawnIcons();
        UpdateUI();
    }

    public void SpawnIcons()
    {
        for (int i = 0; i < habitat.creatures.Count; i++)
        {
            Debug.Log("spawning icon");
            icons.Add(Instantiate(iconPrefab, iconSpawnLocations[i]));
            CreatureIconUI creatureIconUI = icons[i].GetComponent<CreatureIconUI>();
            creatureIconUI.creatureImage.sprite = GameManager.Instance.creatures[i].sprite;
            creatureIconUI.SetTemperatureZone(GameManager.Instance.creatures[i]);
        }
    }

    public void UpdateUI()
    {
        habitat.GetHabitatValue();
        money.text = habitat.HabitatValue.ToString();
    }
}
