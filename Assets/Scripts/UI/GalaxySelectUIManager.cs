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

    public void BringDownTopUI()
    {
        uiAnimator.SetBool("Activate", true);
    }

    public void BringUpTopUI()
    {
        uiAnimator.SetBool("Activate", false);
    }
}