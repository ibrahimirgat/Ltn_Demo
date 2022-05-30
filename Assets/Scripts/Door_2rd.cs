using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2rd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*transform.localScale = new Vector3(transform.localScale.x * 2,
                transform.localScale.y * 2, transform.localScale.z * 2);*/
            Destroy(gameObject, 0.2f);
            Debug.Log("değdi");
        }
    }
}
