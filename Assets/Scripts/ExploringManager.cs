using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploringManager : MonoBehaviour
{
    public GameObject currentBackgroundObject;
    public PlanetData planet;
    public SurfaceUIManager surfaceUIManager;

    private void Start()
    {
        planet = GameManager.Instance.visitingPlanet;
        SetBackground();
        surfaceUIManager.SetUI();
    }

    public void SetBackground()
    {
        currentBackgroundObject.GetComponent<SpriteRenderer>().sprite = planet.planetSurface;
    }
}