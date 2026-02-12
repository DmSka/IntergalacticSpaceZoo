using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnalyizeUIManager : MonoBehaviour
{
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI nameText;

    public Sprite[] sizes;
    public Image sizeImage;

    public GameObject[] rarity;
    public Transform raritySpawnLocation;
    private GameObject spawnedRarity;

    public Image creatureImage;
    public Image homePlanetImage;

    public TextMeshProUGUI planetName;
    public TextMeshProUGUI planetTemperature;

    public void Analyize(Creature creature)
    {
        ageText.text = creature.Age.ToString();
        nameText.text = creature.creatureName;

        sizeImage.sprite = sizes[(int)creature.size];

        if (spawnedRarity == null)
        {
            Destroy(spawnedRarity);
        }

        spawnedRarity = Instantiate(
            rarity[(int)creature.rarity],
            raritySpawnLocation
        );

        creatureImage.sprite = creature.sprite;
        homePlanetImage.sprite = creature.home.planetSprite;
        planetName.text = creature.home.Name;
        planetTemperature.text = creature.home.temperature.ToString();
    }
}
