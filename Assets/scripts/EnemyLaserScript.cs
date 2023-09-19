using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player != null)
            {
                player._audioSource.PlayOneShot(player._explosionSound);
                player.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
