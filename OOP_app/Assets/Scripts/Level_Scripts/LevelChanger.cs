using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    private Animator anim;
    //public int levelToLoad;
    public string levelToLoad;

    public Vector3 position;
    public VectorValue playerStorage;

    public Slider slider;
    public GameObject loadingScreen;

    private void Start()
    {
        anim = GetComponent<Animator>();
        loadingScreen.SetActive(false);
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }
    public void OnFadeComplete()
    {
        playerStorage.initialValue = position;
        SceneManager.LoadScene(levelToLoad);
        StartCoroutine(LoadingScreenOnFade());
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
