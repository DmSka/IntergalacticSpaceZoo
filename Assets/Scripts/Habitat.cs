using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitat : MonoBehaviour
{ 
    public PlanetEnvironmentType.EnvironmentType environment;

    public int size;
    public int temperature;
    public int securityLevel;

    public List<Creature> creatures = new();
    public GameObject[] creatureObjects;

    public MoneyGenerator moneyGenerator;

    public int HabitatValue;

    public void Start()
    {
        creatures = GameManager.Instance.creatures;
        UpdateObject();
    }

    public void GetHabitatValue()
    {
        HabitatValue = 0;

        for (int i = 0; i < creatures.Count; i++)
        {
            HabitatValue += (int)(creatures[i].GetCreatureValue() * 25f + 10f);
        }

        moneyGenerator.moneyPerSecond = HabitatValue;
    }

    public void UpdateObject()
    {
        for (int i = 0; i < creatureObjects.Length; i++)
        {
            creatureObjects[i].SetActive(false);
        }

        for (int i = 0; i < creatures.Count; i++)
        {
            creatureObjects[i].GetComponent<SpriteRenderer>().sprite = creatures[i].sprite;
            creatureObjects[i].SetActive(true);
        }

        GetHabitatValue();
    }

    public void UpdateTemperature(float temperatureIn)
    {
        temperature = (int)temperatureIn;
        UpdateObject();
    }
}
