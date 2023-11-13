using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTransitionButton : MonoBehaviour
{
    public void OnClick()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}