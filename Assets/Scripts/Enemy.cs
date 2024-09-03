using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();

        if (_player == null)
        {
            Debug.LogError("Player object with Player script not found in the scene!");
        }
    }



    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        Vector3 enemyMovementDown = new Vector3(0, -1, 0);
        transform.Translate(enemyMovementDown * speed * Time.deltaTime);


        if (transform.position.y <= -5.39f)
        {
            float randomX = Random.Range(-9.41f, 9.46f);
            transform.position = new Vector3(randomX, 7.5f, 0);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        Debug.Log("Hit: " + other.transform.name);

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.AddScore(10);
            }
            
            
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
           
            if (player != null)
            {
                player.damage();
            }

            Destroy(gameObject);
        }





    }
}
