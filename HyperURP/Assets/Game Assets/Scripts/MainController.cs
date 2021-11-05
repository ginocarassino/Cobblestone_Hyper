using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private PlayerController Player_CTR;

    public GameObject PanelOver;

    [Header("UI")]
    public Text TBullets;

    [Header("Player")]
    public int bulletsNumber = 0;

    void Start()
    {
        Player_CTR = (PlayerController)FindObjectOfType(typeof(PlayerController));
        TBullets.text = bulletsNumber.ToString();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        Player_CTR.isStarted = true;
    }

    public void EndGame()
    {
        PanelOver.SetActive(true);
        Player_CTR.isStarted = false;
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
