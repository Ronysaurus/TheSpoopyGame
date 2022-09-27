using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject block_w, block_b;

    private WaitForSeconds wait;
    private bool isWhite, isFull;

    private void Start()
    {
        wait = new WaitForSeconds(1.5f);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return wait;

        float xPos = Random.Range(0.0f, isFull ? 7.0f : 5.0f) - (isFull ? 3.5f : 2.5f);
        Instantiate(isWhite ? block_w : block_b, new Vector3(xPos, 5.25f), Quaternion.identity);
        isWhite = !isWhite;

        if (!isFull)
            isFull = true;

        if (Mathf.Abs(xPos) > 5.0f)
            isFull = false;

        GameManager.Instance.AddScore();
        StartCoroutine(Spawner());
    }
}