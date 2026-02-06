using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject creaturePrefabObject;

    public void SpawnCreatureForCrate()
    {
        CreatureGenerator creatureGenerator =
            GameObject.Find("CreatureGenerator").GetComponent<CreatureGenerator>();

        // Get the data from generator
        Creature sourceCreature = creatureGenerator.creatures[0];

        // Create a *copy* of the data for this crate
        Creature newCreature = new Creature
        {
            creatureName = sourceCreature.creatureName,
            Age = sourceCreature.Age,
            size = sourceCreature.size,
            breedingType = sourceCreature.breedingType,
            home = sourceCreature.home,
            rarity = sourceCreature.rarity,
            sprite = sourceCreature.sprite
        };


        // Add the data copy to GameManager
        GameManager.Instance.creatures.Add(newCreature);

        GameObject spawnedObject = Instantiate(creaturePrefabObject);
        spawnedObject.GetComponent<SpriteRenderer>().sprite = newCreature.sprite;
    }
}
