using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private PlayerController Player_CTR;

    [Header("Camera")]
    [SerializeField] GameObject _camera;

    [Header("Economy")]
    public int nCollectibles = 0;

    [Header("Player")]
    public CharacterController Hero;
    public MeshRenderer HeroMeshRenderer;
    public ParticleSystem Explosion;
    public int bulletsNumber = 0;

    [Header("Sounds")]
    [SerializeField] AudioSource BGMusic;
    [SerializeField] AudioSource DeathSound;
    [SerializeField] AudioSource WinSound;
    [SerializeField] AudioSource PopUpSound;

    [Header("UI")]
    [SerializeField] GameObject PanelPause;
    [SerializeField] GameObject PanelBlackEnd;
    [SerializeField] GameObject PopUpPanel;
    [SerializeField] GameObject ScorePanel;
    public Text TBullets;

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem Firework;



    void Start()
    {
        Player_CTR = (PlayerController)FindObjectOfType(typeof(PlayerController));
        TBullets.text = bulletsNumber.ToString();

        StartGame();
    }

    void Update()
    {
        
    }

    #region [GAME STATES]
    public void StartGame()
    {
        BGMusic.UnPause();
        Time.timeScale = 1f;

        StartCoroutine(StartRoutine());
    }

    public void EndGame()
    {
        _camera.transform.parent = Hero.transform;
        _camera.GetComponent<Animator>().enabled = true;
        _camera.GetComponent<Animator>().SetBool("isEnd", true);
        Firework.Play();
        BGMusic.Pause();
        WinSound.Play(0);

        PanelBlackEnd.SetActive(true);
        PanelBlackEnd.GetComponent<Animator>().enabled = true;
        StartCoroutine(PopRoutine());
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

    public void Death()
    {
        Hero.enabled = false;
        BGMusic.Stop();
        HeroMeshRenderer.enabled = false;
        Explosion.Play();
        DeathSound.Play(0);

        StartCoroutine(EndRoutine());
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
    #endregion


    #region [ROUTINES]
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
    IEnumerator PopRoutine()
    {
        yield return new WaitForSeconds(2);
        PopUpPanel.SetActive(true);
        PopUpSound.Play(0);

        yield return new WaitForSeconds(8);
        PopUpPanel.SetActive(false);
        ScorePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    #endregion
}
