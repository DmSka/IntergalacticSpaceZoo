using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetData
{
    public int size = 1;                   // planet size
    public Creature[] creatures;           // array of creatures on this planet
    public string Name;
    public int NumberOfTimesVisited = 0;
    public Color planetColor;
    public Sprite planetSprite;
    public Sprite planetSurface;

    public int AntiMatterHazardLevel;
    public int temperature;
    public int Si;
    public int C;

    // Randomize the planet's size and color
    public void Randomize(Sprite[] planetSprites, Sprite[] planetSurfaces)
    {
        // Random size between 1 and 5
        size = Random.Range(1, 6);

        // Random color
        planetColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

        // Random sprite
        if (planetSprites != null && planetSprites.Length > 0)
        {
            planetSprite = planetSprites[Random.Range(0, planetSprites.Length)];
        }

        temperature = Random.Range(0, 100);
        AntiMatterHazardLevel = Random.Range(1, 3);
        Si = Random.Range(0, 4);
        C = Random.Range(2, 9);

        if (planetSurfaces != null && planetSurfaces.Length > 0)
        {
            planetSurface = planetSurfaces[Random.Range(0, planetSurfaces.Length)];
        }
    }
}