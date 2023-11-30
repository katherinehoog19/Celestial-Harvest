using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMenuHandler : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Crop Area");
    }
}
