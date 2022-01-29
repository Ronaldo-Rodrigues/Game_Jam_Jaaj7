using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passagem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            if (other.transform.position.x > 1)
            {
                other.transform.position = new Vector3(-13.5f, transform.position.y,-3);
            }
            else if(other.transform.position.x < -1) 
            {
                other.transform.position = new Vector3(13.5f, transform.position.y,-3);
            }
        }
    }
}
