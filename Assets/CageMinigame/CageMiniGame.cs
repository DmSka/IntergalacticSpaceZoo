using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CageMiniGame : MonoBehaviour
{
    public PoweredWireBehavior[] poweredWiresBehavior;
    public UnpoweredWireStats[] unpoweredWiresStats;

    public List<UnpoweredWireStats> availableWires;

    public Color blue;
    public Color green;
    public Color red;
    public Color yellow;

    public bool MiniGameComplete = false;

    Color GetColor(WireColor color)
    {
        switch (color)
        {
            case WireColor.blue: return blue;
            case WireColor.green: return green;
            case WireColor.red: return red;
            case WireColor.yellow: return yellow;
            default: return Color.white;
        }
    }

    public void Randomize()
    {
        return;

        MiniGameComplete = false;

        for (int i = 0; i < poweredWiresBehavior.Length; i++)
        {
            poweredWiresBehavior[i].Reset();
            unpoweredWiresStats[i].connected = false;
        }

        availableWires = new List<UnpoweredWireStats>(unpoweredWiresStats);

        for (int i = 0; i < poweredWiresBehavior.Length; i++)
        {
            PoweredWireStats pWire = poweredWiresBehavior[i].poweredWireS;
            SpriteRenderer pSR = pWire.GetComponentInParent<SpriteRenderer>();

            // assign random color to powered wire
            pWire.objectColor = (WireColor)Random.Range(
                0,
                System.Enum.GetValues(typeof(WireColor)).Length
            );

            pSR.color = GetColor(pWire.objectColor);

            // pick random available unpowered wire
            int randIndex = Random.Range(0, availableWires.Count);
            UnpoweredWireStats uWire = availableWires[randIndex];

            // assign matching color
            uWire.objectColor = pWire.objectColor;
            uWire.GetComponentInParent<SpriteRenderer>().color =
                GetColor(uWire.objectColor);

            // remove so it can't be reused
            availableWires.RemoveAt(randIndex);
        }
    }

    public void Update()
    {
        bool checking = false;
        //check if all Wires are connected
        for (int i = 0; i < poweredWiresBehavior.Length; i++)
        {
            if (!poweredWiresBehavior[i].poweredWireS.connected)
            {
                checking = false;
                break;
            }

            if (!poweredWiresBehavior[i].poweredWireS.moving)
            {
                checking = false;
                break;
            }

            if (!unpoweredWiresStats[i].connected)
            {
                checking = false;
                break;
            }

            checking = true;
        }

        if (checking)
        {
            //this means game complete
            MiniGameComplete = true;
            CaptureMiniGameManager captureMiniGameManager = GetComponentInParent<CaptureMiniGameManager>();
            captureMiniGameManager.EndCageMiniGame();
            MiniGameComplete = false;
        }
    }
}
