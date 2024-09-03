using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject Triple_Container;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
        destroyLaser();

        
        
        
    }

    void LaserMovement()
    {
        
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        
    }

    void destroyLaser()
    {
        if (transform.position.y >= 7f)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
