using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetTemplate;
    public Transform[] spawnPoints;
    public Sprite[] planetSprites;
    public Sprite[] surfaces;

    [Header("Planet Name Generation")]
    [SerializeField] private string[] prefixes;
    [SerializeField] private string[] syllablesStart;
    [SerializeField] private string[] syllablesMid;
    [SerializeField] private string[] syllablesEnd;
    [SerializeField] private string[] sufixes;

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
        planetObjectScript.planetData.Name = GeneratePlanetName();

        // Update the visuals
        planetObjectScript.Initialize();

        return planetObjectScript.planetData;
    }

    private string GeneratePlanetName()
    {
        if (syllablesStart.Length == 0 || syllablesEnd.Length == 0)
            return "Unnamed Planet";

        int parts = Random.Range(2, 4); // 2–3 syllables
        string name = "";

        if (Random.Range(1, 5) == 1)
        {
            name += prefixes[Random.Range(0, prefixes.Length)] + " ";
        }

        name += syllablesStart[Random.Range(0, syllablesStart.Length)];

        if (parts == 3 && syllablesMid.Length > 0)
        {
            name += syllablesMid[Random.Range(0, syllablesMid.Length)];
        }

        name += syllablesEnd[Random.Range(0, syllablesEnd.Length)];

        if (Random.Range(1, 5) == 1)
        {
            name += " " + sufixes[Random.Range(0, sufixes.Length)];
        }

        return name;
    }
}
