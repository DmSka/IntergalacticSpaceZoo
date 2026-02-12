using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureIconUI : MonoBehaviour
{
    public Image creatureImage;
    public GameObject arrow;
    public GameObject greenZone;
    public Image hunger;


    public void SetTemperatureZone(Creature creature)
    {
        RectTransform redRT = greenZone.transform.parent.GetComponent<RectTransform>();
        RectTransform greenRT = greenZone.GetComponent<RectTransform>();

        float barWidth = redRT.rect.width;

        // Clamp inputs for safety
        float temperature = Mathf.Clamp(creature.home.temperature, 0f, 100f);
        float tolerance = Mathf.Clamp(creature.temperatureTolerance, 0f, 100f);

        // Set green zone width based on tolerance
        float greenWidth = barWidth * (tolerance / 100f);
        greenRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, greenWidth);

        // Position green zone based on temperature
        float normalizedTemp = temperature / 100f;

        float xPos =
            (barWidth * normalizedTemp) - (barWidth / 2f);

        greenRT.anchoredPosition = new Vector2(xPos, greenRT.anchoredPosition.y);

        xPos = Mathf.Clamp(
            xPos,
            -barWidth / 2f + greenWidth / 2f,
            barWidth / 2f - greenWidth / 2f
        );
    }
}
