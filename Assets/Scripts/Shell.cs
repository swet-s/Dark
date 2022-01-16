using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject newparent;

    public void Makeappear()
    {

        transform.SetParent(newparent.transform);
        gameObject.SetActive(true);
    }
}
