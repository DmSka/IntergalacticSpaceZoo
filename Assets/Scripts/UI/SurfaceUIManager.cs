using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceUIManager : MonoBehaviour
{
    public TemperatureUI temperatureUI;
    public RatioUI ratioUI;
    public AntiMatterUI antiMatterUI;

    public Image planetIcon;
    public TextMeshProUGUI cageCount;

    public void SetUI()
    {
        TemperatureMeter();
        AntiMatterHazardMeter();
        RatioMeter();
        planetIcon.sprite = GameManager.Instance.visitingPlanet.planetSprite;
        cageCount.text = GameManager.Instance.cageAmount.ToString();
    }

    public void TemperatureMeter()
    {
        temperatureUI.UpdateBar(GameManager.Instance.visitingPlanet.temperature);
    }

    public void AntiMatterHazardMeter()
    {
        antiMatterUI.UpdateUI(GameManager.Instance.visitingPlanet.AntiMatterHazardLevel);
    }

    public void RatioMeter()
    {
        ratioUI.SetUIScale(GameManager.Instance.visitingPlanet.C, GameManager.Instance.visitingPlanet.Si);
    }
}
