using UnityEngine;

public class UIPanelSlide : MonoBehaviour
{
    public RectTransform panel;   // assign your panel in inspector
    public float slideSpeed = 500f;
    public float targetY = 0f;    // final Y position on screen

    private bool isSliding = false;

    public AudioSource soundEffect;

    void Update()
    {
        if (isSliding && panel != null)
        {
            // move panel towards targetY
            float newY = Mathf.MoveTowards(panel.anchoredPosition.y, targetY, slideSpeed * Time.deltaTime);
            panel.anchoredPosition = new Vector2(panel.anchoredPosition.x, newY);

            // stop sliding when reached
            if (Mathf.Approximately(newY, targetY))
            {
                isSliding = false;
            }
        }
    }

    public void ShowPanel()
    {
        isSliding = true;
        soundEffect.Play();
    }

    public void HidePanel(float hideY = 500f)
    {
        panel.anchoredPosition = new Vector2(panel.anchoredPosition.x, hideY);
        isSliding = false;
    }
}
