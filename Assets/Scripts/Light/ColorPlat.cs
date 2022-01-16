using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlat : MonoBehaviour
{
    public enum RGB {Red, Green, Blue};
    public BackLIght global;
    public RGB myColor;
    Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myColor == RGB.Red && global.lightcolor == BackLIght.CMY.Cyan)
        {
            coll.isTrigger = false;
        }
        else if (myColor == RGB.Green && global.lightcolor == BackLIght.CMY.Megenta)
        {
            coll.isTrigger = false;
        }
        else if (myColor == RGB.Blue && global.lightcolor == BackLIght.CMY.Yellow)
        {
            coll.isTrigger = false;
        }
        else
        {
            coll.isTrigger = true;
        }



    }
}
