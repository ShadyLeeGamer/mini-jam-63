using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public void LoadScene(string scene)
    {

        if (FindObjectOfType<GameGUI>())
        {
            TimeScale.time = 1;
            Player.StopTimeAction -= FindObjectOfType<GameGUI>().StartTiming;
        }

        SceneManager.LoadScene(scene);
    }
}
