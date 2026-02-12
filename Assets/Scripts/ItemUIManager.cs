using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUIManager : MonoBehaviour
{
    public TextMeshProUGUI cageNum;

    public TextMeshProUGUI netNum;
    public GameObject netUnlock;

    public TextMeshProUGUI dartNum;
    public GameObject dartUnlock;

    public void PopulateUI()
    {
        GameManager gm = GameManager.Instance;

        cageNum.text = gm.cageAmount.ToString();

        netUnlock.SetActive(!gm.netOwned);
        netNum.gameObject.SetActive(gm.netOwned);
        if (gm.netOwned)
            netNum.text = gm.netAmount.ToString();

        dartUnlock.SetActive(!gm.dartOwned);
        dartNum.gameObject.SetActive(gm.dartOwned);
        if (gm.dartOwned)
            dartNum.text = gm.dartAmount.ToString();

    }
}
