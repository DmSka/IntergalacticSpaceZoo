using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceUIManager : MonoBehaviour
{
    public TemperatureUI temperatureUI;
    public RatioUI ratioUI;
    public AntiMatterUI antiMatterUI;

    public void SetUI()
    {
        TemperatureMeter();
        AntiMatterHazardMeter();
        RatioMeter();
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
