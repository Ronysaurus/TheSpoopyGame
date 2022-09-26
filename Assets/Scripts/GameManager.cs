using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool whitemode = true;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeMode()
    {
        whitemode = !whitemode;
        foreach (BlockController block in FindObjectsOfType<BlockController>())
        {
            block.isLive = block.isWhite != whitemode;
            block.ChangeMode();
        }
    }

    public void End()
    {
        Time.timeScale = 0.2f;
        StartCoroutine(EndScene());
    }

    private IEnumerator EndScene()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
    }
}