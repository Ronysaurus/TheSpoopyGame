using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 2.0f;
    private Transform myTransform;
    private Renderer myRenderer;
    private int times = 0;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        myTransform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), -4.5f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            GameManager.Instance.ChangeMode();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.End();
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
}