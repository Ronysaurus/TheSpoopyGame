using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool whitemode = true;
    public int hscore = 0;

    [SerializeField]
    private Sprite spriteW, spriteB;

    [SerializeField]
    private AudioSource audioS;

    [SerializeField]
    private TextMeshProUGUI score, highScore, speed;

    [SerializeField]
    private GameObject panel;

    private void Awake()
    {
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
        if (PlayerPrefs.GetInt("score") < hscore || !PlayerPrefs.HasKey("score"))
            PlayerPrefs.SetInt("score", hscore);
        Time.timeScale = 0.2f;
        StartCoroutine(EndScene());
    }

    private IEnumerator EndScene()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
        highScore.text = $"Score: {hscore}\r\nHigh Score : {PlayerPrefs.GetInt("score")}";
        panel.SetActive(true);
    }

    public void AddScore()
    {
        hscore++;
        score.text = hscore.ToString();
        audioS.Play();
    }

    public IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5);
        BlockController.multiplier += 0.1f;
        speed.text = $"x{Math.Round(BlockController.multiplier, 1)}";
        StartCoroutine(SpeedUp());
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}