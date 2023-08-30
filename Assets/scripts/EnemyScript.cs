using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private  float speed = 2.3f;

    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        spawnAndRespawn();
        
    }

    void EnemyMovement()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    void spawnAndRespawn()
    {
       if(this.transform.position.y < -3.68f )
       {
            float randomX = Random.Range(-12f, 12f);
            transform.position = new Vector3(randomX, 7f, 0f);
 
       }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            movementScript player = other.transform.GetComponent<movementScript>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);

        }
        if(other.tag == "Laser" )
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);


        }
    }
}
