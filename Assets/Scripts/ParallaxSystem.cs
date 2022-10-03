using UnityEngine;
using UnityEngine.UI;

public class ParallaxSystem : MonoBehaviour
{
    [SerializeField]
    private Image[] image1;

    [SerializeField]
    private Image[] image2;

    [SerializeField]
    private Image[] image3;

    [SerializeField]
    private Image[] image4;

    private void Update()
    {
        foreach (var image in image1)
        {
            image.transform.Translate(0.1f * Time.deltaTime * Vector3.left);
            if (image.transform.position.x <= -(image.rectTransform.localScale.x * 10))
                image.transform.position = new Vector3(image.rectTransform.localScale.x * 10, image.transform.position.y, image.transform.position.z);
        }
        foreach (var image in image2)
        {
            image.transform.Translate(0.3f * Time.deltaTime * Vector3.left);
            if (image.transform.position.x <= -(image.rectTransform.localScale.x * 10))
                image.transform.position = new Vector3(image.rectTransform.localScale.x * 10, image.transform.position.y, image.transform.position.z);
        }
        foreach (var image in image3)
        {
            image.transform.Translate(0.6f * Time.deltaTime * Vector3.left);
            if (image.transform.position.x <= -(image.rectTransform.localScale.x * 10))
                image.transform.position = new Vector3(image.rectTransform.localScale.x * 10, image.transform.position.y, image.transform.position.z);
        }
        foreach (var image in image4)
        {
            image.transform.Translate(1f * Time.deltaTime * Vector3.left);
            if (image.transform.position.x <= -(image.rectTransform.localScale.x * 10))
                image.transform.position = new Vector3(image.rectTransform.localScale.x * 10, image.transform.position.y, image.transform.position.z);
        }
    }
}