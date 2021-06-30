using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Text textCurrProgress;

    private ParticleSystem particleSys;

    public float fillSpeed = .5f;
    public float currentProgress = 0;

    private void Awake()
    {
        particleSys = GameObject.Find("Particle").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        textCurrProgress.text = "0 %";
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < currentProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;

            if (!particleSys.isPlaying)
            {
                particleSys.Play();
            }
        }
        else
        {
            slider.value = slider.value > slider.maxValue ? slider.maxValue : slider.value;
            particleSys.Stop();
        }
    }

    private void FixedUpdate()
    {
        textCurrProgress.text = slider.value.ToString("##0") + " %";
    }
}
