using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 5f;

    public void LoadScene(int idx)
    {
        LoadNextLevel(idx);
    }

    private int numberOfScenes = 2;

    private void LoadNextLevel( int idx)
    {
        StartCoroutine(LoadLevel(idx));
    }

    private IEnumerator LoadLevel(int idx)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(idx);
    }
}
