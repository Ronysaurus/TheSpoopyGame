using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 2.0f;
    private Renderer myRenderer;
    private int times = 0;
    private bool canChange;

    private void Start()
    {
        canChange = true;
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = (Input.acceleration.x * 2) + Input.GetAxis("Horizontal");

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), -4.5f, 0);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && canChange)
        {
            GameManager.Instance.ChangeMode();
            canChange = false;
            StartCoroutine(Cooldown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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