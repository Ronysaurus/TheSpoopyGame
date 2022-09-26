using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isWhite;

    private Renderer[] myRenderer;
    public float speed = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        myRenderer = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in myRenderer)
        {
            renderer.material.color = isWhite ? Color.white : Color.black;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }
}