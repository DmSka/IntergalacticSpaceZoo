using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenerator : MonoBehaviour
{
    public float moneyPerSecond = 5f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            int seconds = Mathf.FloorToInt(timer);
            AddMoney(seconds * moneyPerSecond);
            timer -= seconds;
        }
    }

    void AddMoney(float amount)
    {
        GameManager.Instance.money += (int)amount;
    }
}
