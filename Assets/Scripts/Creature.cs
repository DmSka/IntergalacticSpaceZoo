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
}
