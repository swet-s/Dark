using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlank : MonoBehaviour
{
    public GameObject[] childs;
    Vector3[] pos = new Vector3[4];
    private void Start()
    {
        int i = 0;
        foreach (GameObject child in childs)
        {
            pos[i] = child.transform.position;
            i++;
        }
    }
    public void reset()
    {
        int i = 0;
        foreach (GameObject child in childs)
        {
            Instantiate(child, pos[i], transform.rotation);
            i++;
        }
    }
}
