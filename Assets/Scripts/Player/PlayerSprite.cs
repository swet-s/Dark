using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSprite 
{
    public  static void ChangeSprite(GameObject player, int index)
    {
        Sprite player0 = Resources.Load<Sprite>("Player_01");
        Sprite player1 = Resources.Load<Sprite>("Player1");
        Sprite player2 = Resources.Load<Sprite>("Player2");
        if (index == 1)
            player.GetComponent<SpriteRenderer>().sprite = player1;
        else if (index == 2)
        {
            player.GetComponent<SpriteRenderer>().sprite = player2;
            
        }
        else
            player.GetComponent<SpriteRenderer>().sprite = player0;
    }

}
