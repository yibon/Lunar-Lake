using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitTime = 1f;

    #region SINGLETON SCRIPT AHAHAHHAHAHAHAHAH
    public static LevelLoader instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
    #endregion


    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Loadlevel(int levelindex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitTime);

        SceneManager.LoadScene(levelindex);
    }
}
