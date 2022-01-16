using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPooler : MonoBehaviour
{
    ObjectPooler objectPooler;


    public GameObject stuff0;
    public GameObject quad;
    public Vector2 scaleRange;
    Vector2 min;
    Vector2 max;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;

        MeshFilter quadMesh = quad.GetComponent<MeshFilter>();
        Transform quadTransform = quad.GetComponent<Transform>();
        min = quadTransform.TransformPoint(quadMesh.mesh.vertices[0]);
        max = quadTransform.TransformPoint(quadMesh.mesh.vertices[3]);
    }

    public void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 1f);
        GameObject stuff = Instantiate(stuff0, pos, Quaternion.identity);
        float aNumber = Random.Range(scaleRange.x, scaleRange.y);
        stuff.transform.localScale = new Vector3(aNumber, aNumber, 1);
    }


    #region SlowUpdate

    public bool doable = true;
    public float delay;

    private void Update()
    {
        if (doable)
        {
            StartCoroutine("doAfter");
            Spawn();
            doable = false;
        }
    }

    IEnumerator doAfter()
    {
        yield return new WaitForSeconds(delay);
        doable = true;
    }

    #endregion
}
