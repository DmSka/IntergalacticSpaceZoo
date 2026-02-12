using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Image goldFillImage;
    public TextMeshProUGUI goldText;

    public float maxGold = 1500f;

    private float currentGold = 0f;

    public void SetGold(float amount)
    {
        currentGold = Mathf.Clamp(amount, 0f, maxGold);

        // Update bar
        goldFillImage.fillAmount = currentGold / maxGold;

        // Update text
        goldText.text = Mathf.FloorToInt(currentGold).ToString();
    }

    public void Update()
    {
        SetGold(GameManager.Instance.money);
    }
}
