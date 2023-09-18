using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] float speed;
    public bool enemyLaser = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyLaser)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }


    void MoveUp()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        if ( this.transform.position.y > 5f)
        {
            if ( this.transform.parent != null)
            {
                Destroy( this.transform.parent.gameObject );
            }

            Destroy(this.gameObject);
        }
    }
    void MoveDown()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (this.transform.position.y < -5f)
        {
            if (this.transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
    public void AssignEnemyLaser()
    {
        enemyLaser = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && enemyLaser)
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player!= null )
            {
                player._audioSource.PlayOneShot(player._explosionSound);
                player.Damage();
            }
        }
    }
}
