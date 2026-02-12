using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Creature
{
    public enum BreedingType { asexual, mitosis, sexual }
    public enum Size { small, medium, large }
    public enum Rarity { common, uncommon, epic, legendary }

    public string creatureName;
    public int Age;
    public Size size;
    public BreedingType breedingType;
    public PlanetData home;
    public Rarity rarity;
    public Sprite sprite;
    public float temperatureTolerance = 10;

    // Convert Size enum to an int
    public int GetIntFromSize()
    {
        switch (size)
        {
            case Size.small:
                return 1;
            case Size.medium:
                return 2;
            case Size.large:
                return 3;
            default:
                return 1; // fallback
        }
    }

    public float GetMultFromRarity()
    {
        switch (rarity)
        {
            case Rarity.common:
                return 1.15f;
            case Rarity.uncommon:
                return 2.25f;
            case Rarity.epic:
                return 5f;
            case Rarity.legendary:
                return 10f;
            default:
                return 1; // fallback
        }
    }

    public float GetCreatureValue()
    {
        return (GetIntFromSize() * GetMultFromRarity());
    }
}
