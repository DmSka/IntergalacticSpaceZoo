using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreButton : MonoBehaviour
{
    public void ExploreButtonClicked()
    {
        SceneManager.LoadScene("SurfaceExploring");
    }
}
