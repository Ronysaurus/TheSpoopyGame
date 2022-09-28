using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool whitemode = true;
    public int hscore = 0;

    [SerializeField]
    TextMeshProUGUI score;

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
        StartCoroutine(SpeedUp());
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

    public void AddScore()
    {
        hscore++;
        score.text = hscore.ToString();
    }

    public IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(10);
        BlockController.speed += 0.1f;
        Debug.Log(BlockController.speed);
        StartCoroutine(SpeedUp());
    }
}