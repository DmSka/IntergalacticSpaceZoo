using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<PlanetData> generatedPlanets = new List<PlanetData>(); // all planets in current scene
    public List<PlanetData> visitedPlanets = new List<PlanetData>();

    public List<Creature> creatures = new();

    public PlanetData selectedPlanet;
    public PlanetData visitingPlanet;

    public int cageAmount = 1;
    public int netAmount;
    public int dartAmount;

    public bool netOwned;
    public bool dartOwned;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool checkIfVisited(PlanetData planet)
    {
        return visitedPlanets.Contains(planet);
    }

    public void explorePlanet()
    {
        visitingPlanet = selectedPlanet;

        // add to visited if not already
        if (!visitedPlanets.Contains(visitingPlanet))
            visitedPlanets.Add(visitingPlanet);
    }

    public int GetItemCount(string item)
    {
        switch (item.ToLower())
        {
            case "cage": return cageAmount;
            case "net": return netAmount;
            case "dart": return dartAmount;
            default: return 0;
        }
    }

    public bool OwnsItem(string item)
    {
        switch (item.ToLower())
        {
            case "net": return netOwned;
            case "dart": return dartOwned;
            default: return true; // cages are always owned
        }
    }
}