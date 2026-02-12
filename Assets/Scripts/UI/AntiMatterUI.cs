using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiMatterUI : MonoBehaviour
{
    public Image[] levels;
    public int hazardLevel;

    public void UpdateUI(int hazard)
    {
        hazardLevel = hazard;
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].color = Color.white;
        }

        for (int i = 0; i < hazardLevel; i++)
        {
            levels[i].color = Color.red;
        }
    }
}
