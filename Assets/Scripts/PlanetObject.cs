using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetObject : MonoBehaviour
{
    public SpriteRenderer sr;
    private Color originalColor;
    public Color highlightColor = Color.yellow;  // glow color
    public Color selectedColor = Color.red;

    public PlanetData planetData;

    public bool isHovered = false;
    public bool isSelected = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        transform.localScale = Vector3.one * planetData.size / 50f;
        sr.sprite = planetData.planetSprite;

        ApplyColor();
    }

    private void ApplyColor()
    {
        if (isSelected)
            sr.color = selectedColor;
        else if (isHovered)
            sr.color = highlightColor;
        else
            sr.color = planetData.planetColor;
    }

    void OnMouseEnter()
    {
        isHovered = true;
        ApplyColor();
    }

    void OnMouseExit()
    {
        isHovered = false;
        ApplyColor();
    }

    void OnMouseDown()
    {
        GalaxySelectManager galaxySelectManager = GameObject.Find("GalaxySelectManager").GetComponent<GalaxySelectManager>();
        if (galaxySelectManager.selectedPlanetObject != null)
        {
            galaxySelectManager.selectedPlanetObject.SetSelected(false);
        }
        galaxySelectManager.selectedPlanetObject = this;
        galaxySelectManager.galaxySelectUIManager.BringDownTopUI();
        GameManager.Instance.selectedPlanet = planetData;
        SetSelected(true);
    }

    public void SetSelected(bool value)
    {
        isSelected = value;
        ApplyColor();
    }
}
