using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public enum BreedingType { asexual, mitosis, sexual}
    
    public int Age;
    public BreedingType breedingType;
    public PlanetData home;

}
