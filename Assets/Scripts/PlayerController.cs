using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 2.0f;
    private Renderer myRenderer;
    private int times = 0;
    private bool canChange;
    private Color color1 = new Color();
    private Color color2 = new Color();

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out color1);
        ColorUtility.TryParseHtmlString("#2E282A", out color2);

        canChange = true;
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.color = color1;
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
            myRenderer.material.color = GameManager.Instance.whitemode ? color1 : color2;
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