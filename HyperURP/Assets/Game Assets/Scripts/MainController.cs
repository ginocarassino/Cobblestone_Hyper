using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private PlayerController Player_CTR;

    

    [Header("Player")]
    public CharacterController Hero;
    public MeshRenderer HeroMeshRenderer;
    public ParticleSystem Explosion;
    public int bulletsNumber = 0;

    [Header("Sounds")]
    public AudioSource BGMusic;
    public AudioSource DeathSound;

    [Header("UI")]
    public GameObject PanelPause;
    public Text TBullets;



    void Start()
    {
        Player_CTR = (PlayerController)FindObjectOfType(typeof(PlayerController));
        TBullets.text = bulletsNumber.ToString();

        StartGame();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        BGMusic.UnPause();
        Time.timeScale = 1f;

        StartCoroutine(StartRoutine());
    }

    public void EndGame()
    {
        Hero.enabled = false;
        BGMusic.Stop();
        HeroMeshRenderer.enabled = false;
        Explosion.Play();
        DeathSound.Play(0);

        StartCoroutine(EndRoutine());
    }

    public void PauseGame()
    {
        PanelPause.SetActive(true);
        BGMusic.Pause();
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        PanelPause.SetActive(false);
        BGMusic.UnPause();
        Time.timeScale = 1f;
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(1);
        Player_CTR.isStarted = true;
        BGMusic.Play(0);
    }
    IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(1);
        StartAgain();
    }
}
