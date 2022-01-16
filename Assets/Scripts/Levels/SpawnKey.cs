using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject[] keys;
    public GameObject[] platforms;
    public Vector3 offset;
    public float changeTime;
    GameObject targetedKey;
    GameObject targetedPlatform;
    bool changable = true;
    void FixedUpdate()
    {
        if (changable)
        {
            changable = false;
            StartCoroutine(changePos());
        }
    }

    IEnumerator changePos()
    {
        int randonNo = Random.Range(0, platforms.Length);
        foreach (GameObject key in keys)
        {
            if (key.activeSelf)
            {
                targetedKey = key;
                key.transform.position = platforms[randonNo].transform.position + offset;
            }
        }
        yield return new WaitForSeconds(changeTime);
        changable = true;
    }
}
