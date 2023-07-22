using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim : MonoBehaviour
{
    public Transform point1, point2, point3;
    public GameObject dotPrefab;

    Vector3 point, midPoint;
    GameObject dot;

    void Start()
    {
        dot = Instantiate(dotPrefab, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2)), Quaternion.identity);

        for (int i = 0; i < 100000; i++)
        {
            
        }
    }

    void Update()
    {
        int rand = Random.Range(1, 4);

        switch (rand)
        {
            case 1:
                point = point1.position;
                break;
            case 2:
                point = point2.position;
                break;
            case 3:
                point = point3.position;
                break;
        }

        midPoint = (point + dot.transform.position) / 2;
        dot = Instantiate(dotPrefab, midPoint, Quaternion.identity);


        if (Input.GetKey(KeyCode.Mouse0))
        {
            Camera.main.orthographicSize += 1000 * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.Mouse1))
        {
            Camera.main.orthographicSize -= 1000 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
