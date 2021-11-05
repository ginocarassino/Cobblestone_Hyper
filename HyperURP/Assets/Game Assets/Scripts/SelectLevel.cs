using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public void LevelSelection(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
