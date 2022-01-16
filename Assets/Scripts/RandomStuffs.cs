using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStuffs : MonoBehaviour
{
    public GameObject stuff;
    public int total;
    public float separation;
    public GameObject quad;
    public Vector2 scaleRange;
    Vector2 min;
    Vector2 max;
    void Start()
    {
        MeshFilter quadMesh = quad.GetComponent<MeshFilter>();
        Transform quadTransform = quad.GetComponent<Transform>();
        min = quadTransform.TransformPoint(quadMesh.mesh.vertices[0]);
        max = quadTransform.TransformPoint(quadMesh.mesh.vertices[3]);


        GameObject[] stuffs = new GameObject[total];
        Vector3[] position = new Vector3[total];
        for (int i = 0; i < total; i++)
        {
            position[i] = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 1f);
        }
        for (int i = 0; i < total; i++)
        {
            stuffs[i] = Instantiate(stuff, Vector3.zero, stuff.transform.rotation);
            stuffs[i].transform.parent = gameObject.transform;
            stuffs[i].transform.position = position[i] * separation;
            float aNumber = Random.Range(scaleRange.x, scaleRange.y);
            stuffs[i].transform.localScale = new Vector3(aNumber, aNumber, 1);

        }
    }
}
