using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToShipButton : MonoBehaviour
{
    public void ReturnToShip()
    {
        SceneManager.LoadScene("Ship");
    }
}
