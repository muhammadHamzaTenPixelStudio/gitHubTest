using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField] int speedOfRot;
    public GameObject explosion; 
    private SpawningManager _spawningManager;
    private SpawningManager _Player;
    // Start is called before the first frame update
    void Start()
    {
       
        _spawningManager = GameObject.Find("SpawnManager").GetComponent<SpawningManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * speedOfRot *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
           
            Instantiate(explosion, transform.position,Quaternion.identity);
            Destroy(this.gameObject,.25f);
            Destroy(other.gameObject); 
            _spawningManager.StartSpawn();

        }
    }
}
