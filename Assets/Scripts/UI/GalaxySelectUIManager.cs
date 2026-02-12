using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GalaxySelectUIManager : MonoBehaviour
{
    public Animator uiAnimator;
    
    public TextMeshProUGUI Name;
    public TextMeshProUGUI ExploredNumber;

    private GameManager gm;

    public void Start()
    {
        gm = GameManager.Instance;
    }

    public void BringDownTopUI()
    {
        uiAnimator.SetBool("Activate", true);
        UpdateUI();
    }

    public void BringUpTopUI()
    {
        uiAnimator.SetBool("Activate", false);
        UpdateUI();
    }

    public void UpdateUI()
    {
        Name.text = gm.selectedPlanet.Name;
        ExploredNumber.text = gm.selectedPlanet.NumberOfTimesVisited.ToString();
    }
}