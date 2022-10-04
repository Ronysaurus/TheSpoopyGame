using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteW, spriteB;

    private readonly float speed = 3.0f;
    private SpriteRenderer myRenderer;
    private int times = 0;
    private bool canChange;

    private void Start()
    {
        canChange = true;
        myRenderer = GetComponentInChildren<SpriteRenderer>();
        myRenderer.sprite = spriteW;
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = (Input.acceleration.z * 2.5f) + (-Input.GetAxis("Vertical"));

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

        transform.position = new Vector3(-8.35f, Mathf.Clamp(transform.position.y, 0.25f, 8f), 0);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && canChange)
        {
            GameManager.Instance.ChangeMode();
            myRenderer.sprite = GameManager.Instance.whitemode ? spriteW : spriteB;
            canChange = false;
            StartCoroutine(Cooldown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.AddScore();
            return;
        }
        GameManager.Instance.End();
        Destroy(other.gameObject);
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        myRenderer.enabled = !myRenderer.enabled;
        yield return new WaitForSecondsRealtime(0.5f);
        if (times <= 4)
        {
            times++;
            StartCoroutine(Death());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        canChange = true;
    }
}