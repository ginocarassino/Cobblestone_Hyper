using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0f;
    public float FillSpeed = 0.5f;
    private ParticleSystem particleSys;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        IncrementProgress(0.75f);
    }

    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying)
            {
                particleSys.Play();
            }
            else { particleSys.Stop(); }
        }
    }

    public void IncrementProgress(float progress)
    {
        targetProgress = slider.value + progress;
    }
}
