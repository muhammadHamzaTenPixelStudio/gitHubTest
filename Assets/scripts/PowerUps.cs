using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float speed = 2.3f;
    PlayerScript _player;
    [SerializeField] int _powerUpId; 
    public AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        
        _player = GameObject.Find("Player (1)").transform.GetChild(0).GetComponent<PlayerScript>();
        if (_player == null)
        {
            Debug.Log("player is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnAndRespawn();
        PowerUpMovement();
    }

    void PowerUpMovement()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    void spawnAndRespawn()
    {
        if (this.transform.position.y < -3.68f)
        {
            float randomX = Random.Range(-12f, 12f);
            transform.position = new Vector3(randomX, 7f, 0f);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_clip, this.transform.position);
            if(_powerUpId==0)
            {
                _player.EnableTripleShot();
                Destroy(this.gameObject);
            }
            else if(_powerUpId==1)
            {
                _player.EnhanceSpeed();
                Destroy(this.gameObject);
            } 
            else if(_powerUpId==2)
            {
                _player.ActiveShield();
                Destroy(this.gameObject);
            }

        }
    }
    

}
