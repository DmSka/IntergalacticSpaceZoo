using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploringManager : MonoBehaviour
{
    public GameObject currentBackgroundObject;

    public PlanetData planet;

    private void Start()
    {
        SetBackground();
        SetPlanetIcon();
        planet = GameManager.Instance.visitingPlanet;
    }

    public void SetBackground()
    {
        currentBackgroundObject.GetComponent<SpriteRenderer>().sprite = planet.planetSurface;
    }

    public void SetPlanetIcon()
    {

    }
}