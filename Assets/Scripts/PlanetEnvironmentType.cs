using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnvironmentType : MonoBehaviour
{
    public enum EnvironmentType
    {
        Desert,
        Forest,
        Ocean,
        Mountain,
        Arctic,
        Urban
    }

    public EnvironmentType environment;

    public int temperature;
    public int density;

    public void Randomize()
    {
        temperature = Random.Range(0, 90);
        density = Random.Range(0, 5);
    }
}
