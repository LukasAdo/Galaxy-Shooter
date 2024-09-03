using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private int powerID;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -7f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
          
            switch (powerID)
            {
                case 0:
                    player.EnableTripleShot();
                    break;
                case 1:
                    player.EnableSpeedPowerUp();
                    break;
                case 2:
                    player.EnableShieldPowerUp();
                    break;
            }
            Destroy(this.gameObject);
        }
       
    }
}
