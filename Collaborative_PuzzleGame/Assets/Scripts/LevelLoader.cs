using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.01f;

    public bool load = false;

    // Update is called once per frame
    void Update()
    {
        if (load)
        {
            LoadNextLevel();
            load = false;
        }
    }

    public void LoadNextLevel()
    {
        //"delay some code" with Coroutine...
        IEnumerator coroutine = LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(coroutine);
    }

    IEnumerator LoadLevel(int index)
    {
        //play animation
        transition.SetTrigger("Start Crossfade");

        //don't need to play the second part, the "End Crossfade" animation, as it automatically plays when entering a level

        //wait
        yield return new WaitForSeconds(transitionTime);  //pauses this CoRoutine for X amount of seconds before processing rest...

        //load scene
        SceneManager.LoadScene(index);
    }
}
