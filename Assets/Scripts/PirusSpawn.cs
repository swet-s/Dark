using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirusSpawn : MonoBehaviour
{
    public GameObject pirus;
    public GameObject quad;
    [Range(10, 1000)]
    public int prob;
    public Vector2 scaleRange;
    Vector2 min;
    Vector2 max;
    void Start()
    {
        MeshFilter quadMesh = quad.GetComponent<MeshFilter>();
        Transform quadTransform = quad.GetComponent<Transform>();
        min = quadTransform.TransformPoint(quadMesh.mesh.vertices[0]);
        max = quadTransform.TransformPoint(quadMesh.mesh.vertices[3]);

    }
        // Update is called once per frame
        void FixedUpdate()
    {
        if (Random.Range(0, prob) == 1)
        {
            Vector3 position = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 1f);
            
            GameObject pt = Instantiate(pirus, transform.position, Quaternion.identity);
            pt.transform.parent = gameObject.transform;
            pt.transform.position = position;
            float randScale = Random.Range(0.5f, 0.8f);
            pt.transform.localScale = new Vector3(randScale, randScale, 1);
            pt.GetComponent<EnemyHealth>().DieAfter(4f);
        }
    }
}
