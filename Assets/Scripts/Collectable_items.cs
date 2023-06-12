using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectable_items : MonoBehaviour
{
    
    public Player player;
    public bool stwb;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            IncreaseScore();
            stwb = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            stwb = false;
        }
    }
    public void IncreaseScore()
    {
        player._score ++;
    }
    
}
