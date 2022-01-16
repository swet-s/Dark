using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BackLIght : MonoBehaviour
{
    public Light2D global;
    public Vector3 clock;
    float currentTime = 0f;
    public enum CMY {White, Cyan, Megenta, Yellow};
    public CMY lightcolor;
    Color wallColor = new Color(1f, 1f, 1f, 1f);

    void Start()
    {
        global = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTime > 0 && currentTime < clock.x)
        {
            wallColor = new Color(0f, 1f, 1f, 1f);
            lightcolor = CMY.Cyan;
        }
        else if (currentTime > clock.x && currentTime < clock.y)
        {
            wallColor = new Color(1f, 0f, 1f, 1f);
            lightcolor = CMY.Megenta;
        }
        else if (currentTime > clock.y && currentTime < clock.z)
        {
            wallColor = new Color(1f, 1f, 0f, 1f);
            lightcolor = CMY.Yellow;
        }
        else
            currentTime = 0;


        global.color = wallColor;
        currentTime += Time.fixedDeltaTime;

    }
}
