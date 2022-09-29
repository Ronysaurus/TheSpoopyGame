using UnityEngine;

public class BlockController : MonoBehaviour
{
    //https://coolors.co/ffffff-2e282a-0c7489-434eaa-7a28cb Colors
    public bool isWhite;

    private Renderer[] myRenderer;
    private Collider[] myCollider;
    public float speed = 2.0f;
    public static float multiplier = 1.0f;
    public bool isLive;

    private void Start()
    {
        Color color1 = new Color();
        ColorUtility.TryParseHtmlString("#FFFFFF", out color1);
        Color color2 = new Color();
        ColorUtility.TryParseHtmlString("#2E282A", out color2);

        myRenderer = GetComponentsInChildren<Renderer>();
        myCollider = GetComponentsInChildren<Collider>();
        foreach (Renderer renderer in myRenderer)
        {
            renderer.material.color = isWhite ? color1 : color2;
        }
        isLive = GameManager.Instance.whitemode != isWhite;
        Destroy(this, 6);
        ChangeMode();
    }

    private void Update()
    {
        transform.Translate(speed * multiplier * Time.deltaTime * -Vector3.up);
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