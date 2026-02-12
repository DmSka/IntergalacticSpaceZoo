using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GalaxySelectManager : MonoBehaviour
{
    public Galaxy galaxy;
    public PlanetGenerator planetGenerator;
    public List<PlanetObject> planetObjects;
    public PlanetObject selectedPlanetObject;
    public GalaxySelectUIManager galaxySelectUIManager;

    public void Start()
    {
        planetGenerator.GeneratePlanets();
    }
    public void SelectPlanet()
    {
        GameManager.Instance.explorePlanet();
        
    }
}
