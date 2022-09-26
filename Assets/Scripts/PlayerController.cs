using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 2.0f;
    private Transform myTransform;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        myTransform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), -4.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}