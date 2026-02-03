using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreButton : MonoBehaviour
{
    public void ExploreButtonClicked()
    {
        Debug.Log("Going to surface");
        SceneManager.LoadScene("SurfaceExploring");
    }
}
