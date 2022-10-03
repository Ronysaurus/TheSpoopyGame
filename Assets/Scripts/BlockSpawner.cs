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

        float yPos = Random.Range(0, isFull ? 9.5f : 7.75f) - (isFull ? -0.5f : 0.75f);
        GameObject @object = Instantiate(isWhite ? block_w : block_b, new Vector3(9.25f, yPos), Quaternion.Euler(0, 0, -90));
        Destroy(@object, 10);
        isWhite = !isWhite;

        if (!isFull)
            isFull = true;

        if (yPos > 7.75f || yPos < 0.75f)
            isFull = false;

        GameManager.Instance.AddScore();
        StartCoroutine(Spawner());
    }
}