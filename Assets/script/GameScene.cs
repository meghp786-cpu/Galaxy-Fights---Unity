using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    [SerializeField] private int realoadTime = 2;

    public void ReloadScene()
    {
        StartCoroutine(ReloadAfterSec());
    }
    IEnumerator ReloadAfterSec()
    {
        yield return new WaitForSeconds(realoadTime);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
