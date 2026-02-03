using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetTemplate;
    public Transform[] spawnPoints;
    public Sprite[] planetSprites;
    public Sprite[] surfaces;

    public List<PlanetData> GeneratePlanets()
    {
        List<PlanetData> randomPlanets = new List<PlanetData>(); // initialize the list

        for (int i = 0; i < spawnPoints.Length - 1; i++)
        {
            // 50% chance to spawn a planet
            if (Random.Range(0, 2) == 1)
            {
                PlanetData p = GeneratePlanet(i);
                randomPlanets.Add(p);
            }
        }
        // Always spawn a planet at the last spawn point
        PlanetData lastPlanet = GeneratePlanet(spawnPoints.Length - 1);
        randomPlanets.Add(lastPlanet);

        return randomPlanets;
    }

    public PlanetData GeneratePlanet(int index)
    {
        GameObject newPlanetObject = Instantiate(planetTemplate, spawnPoints[index].position, Quaternion.identity);
        PlanetObject planetObjectScript = newPlanetObject.GetComponent<PlanetObject>();

        // Randomize the planet using the sprite array
        planetObjectScript.planetData.Randomize(planetSprites, surfaces);

        // Update the visuals
        planetObjectScript.Initialize();

        return planetObjectScript.planetData;
    }
}
