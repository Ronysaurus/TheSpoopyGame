using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject credits, main;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        main.SetActive(true);
        credits.SetActive(false);
    }

    public void Credits()
    {
        main.SetActive(false);
        credits.SetActive(true);
    }

    public void Donate()
    {
        Application.OpenURL("https://ko-fi.com/ronysaurus");
    }
}