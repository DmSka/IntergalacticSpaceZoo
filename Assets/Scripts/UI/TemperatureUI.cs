using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureUI : MonoBehaviour
{
    [Range(0f, 100f)]
    public float temperature = 50f;

    public Image fillImage;

    public Color coldColor = Color.blue;
    public Color hotColor = Color.red;

    public TextMeshProUGUI number;

    public void UpdateBar(float temp)
    {
        float t = Mathf.InverseLerp(0f, 100f, temp);

        fillImage.fillAmount = t;

        fillImage.color = Color.Lerp(coldColor, hotColor, t);

        number.text = temp.ToString();
    }
}
