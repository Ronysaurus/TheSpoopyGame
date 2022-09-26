using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isWhite;

    private Renderer[] myRenderer;
    private Collider[] myCollider;
    public float speed = 2.0f;
    public bool isLive;

    private void Start()
    {
        myRenderer = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in myRenderer)
        {
            renderer.material.color = isWhite ? Color.white : Color.black;
        }
        Destroy(this, 6);
    }

    private void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }

    public void ChangeMode()
    {
        foreach (Renderer renderer in myRenderer)
        {
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, isLive ? 1.0f : 0.2f);
        }
        foreach (Collider collider in myCollider)
        {
            collider.enabled = isLive;
        }
    }
}