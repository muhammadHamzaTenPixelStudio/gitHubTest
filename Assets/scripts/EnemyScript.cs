using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private  float speed = 2.3f;
    PlayerScript _player;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    public AudioClip _explosionSound;
    public AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _player = GameObject.Find("Player (1)").transform.GetChild(0).GetComponent<PlayerScript>();
        _animator = GetComponent<Animator>();
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
            _audioSource.Play();

            if (_player != null)
            {
                _player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            Destroy(this.gameObject,2.8f);

        }
        if (other.tag == "Laser")
        {
            _audioSource.Play();
            _animator.SetTrigger("OnEnemyDeath");
            speed = 0.5f;
            _boxCollider.enabled = false;
            Destroy(other.gameObject);
            _player.AddScore(10);
            Destroy(this.gameObject, 2.8f);
        }
    }
}
