using UnityEngine;
using TMPro;
using System.Numerics;

public class RatioUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform carbonScaler;
    public RectTransform siliconScaler;

    public int C;
    public int Si;

    public void SetUIScale(int Cnum, int Snum)
    {
        C = Cnum;
        Si = Snum;
        if (C <= 0 && Si <= 0)
        {
            return;
        }

        float carbonRatio = 1f;
        float siliconRatio = 1f;

        if (C >= Si && C > 0)
        {
            siliconRatio = (float)Si / C;
        }
        else if (Si > C && Si > 0)
        {
            carbonRatio = (float)C / Si;
        }

        UnityEngine.Vector3 temp = carbonScaler.localScale;
        temp.x = carbonRatio;
        temp.y = carbonRatio;
        temp.z = carbonRatio;
        carbonScaler.localScale = temp;

        UnityEngine.Vector3 temp2 = siliconScaler.localScale;
        temp2.x = siliconRatio;
        temp2.y = siliconRatio;
        temp2.z = siliconRatio;
        siliconScaler.localScale = temp2;


        text.text = $"{C}:{Si}";
    }
}