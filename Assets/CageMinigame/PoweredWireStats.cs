using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WireColor { blue, green, red, yellow};
public class PoweredWireStats : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public WireColor objectColor;
    public Vector3 startPosition;
    public bool connected = false;
    public Vector3 connectedPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
}
