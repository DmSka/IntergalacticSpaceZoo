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

    public PlanetData selectedPlanet;
    public PlanetData visitingPlanet;

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
        for (int i = 0; i < visitedPlanets.Count; i++)
            if (visitedPlanets[i] == planet)
                return true;
        return false;
    }

    public void explorePlanet(PlanetData planet)
    {
        visitingPlanet = planet;

        // add to visited if not already
        if (!visitedPlanets.Contains(planet))
            visitedPlanets.Add(planet);

        // increment visit count
        planet.NumberOfTimesVisited++;

        SceneManager.LoadScene("Exploring");
    }
}