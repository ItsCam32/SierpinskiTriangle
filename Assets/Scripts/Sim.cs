using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sim : MonoBehaviour
{
    // vv Private Exposed vv //

    [SerializeField]
    private Slider iterationsSlider;

    [SerializeField]
    private TextMeshProUGUI iterationsText;

    [SerializeField]
    private GameObject mainMenuObj;

    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private GameObject dotPrefab;

    // vv Private vv //

    private Vector3 point = Vector3.zero;
    private Vector3 midPoint = Vector3.zero;
    private GameObject dot = null;
    private float magicColourScale = 40.0f;

    ////////////////////////////////////////

    #region Public Functions

    public void OnIterationsSliderChanged()
    {
        iterationsText.text = iterationsSlider.value.ToString("F0");
    }

    public void OnStartButtonClicked()
    {
        mainMenuObj.SetActive(false);
        Simulate(Mathf.RoundToInt(iterationsSlider.value));
    }

    public void Simulate(int iterations)
    {
        float x = Random.Range(0, Screen.width);
        float y = Random.Range(0, Screen.height);
        float z = Camera.main.farClipPlane / 2;
        dot = Instantiate(dotPrefab, Camera.main.ScreenToWorldPoint(new Vector3(x, y, z)), Quaternion.identity);

        for (int i = 0; i < iterations; i++)
        {
            point = points[Random.Range(0, 3)].position;
            midPoint = (point + dot.transform.position) / 2.0f;
            dot = Instantiate(dotPrefab, midPoint, Quaternion.identity);
            dot.GetComponent<SpriteRenderer>().color = new Color(dot.transform.position.x / magicColourScale, dot.transform.position.y / magicColourScale, 0.5f, 1.0f);
        }
    }

    public void OnQuitGameClicked()
    {
        Application.Quit();
    }
    #endregion
}
