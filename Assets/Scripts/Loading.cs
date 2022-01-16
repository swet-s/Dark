using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text load;
    void Start()
    {
        load.text = "";
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1.0f);


        load.text = "L";
        yield return new WaitForSeconds(0.05f);
        load.text = "Lo";
        yield return new WaitForSeconds(0.05f);
        load.text = "Loa";
        yield return new WaitForSeconds(0.05f);
        load.text = "Load";
        yield return new WaitForSeconds(0.05f);
        load.text = "Loadi";
        yield return new WaitForSeconds(0.05f);
        load.text = "Loadin";
        yield return new WaitForSeconds(0.05f);
        load.text = "Loading";
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            load.text = "Loading.";
            yield return new WaitForSeconds(0.5f);
            load.text = "Loading..";
            yield return new WaitForSeconds(0.5f);
            load.text = "Loading...";
        }

    }

}
