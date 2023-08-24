using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int _life = 3;
    private float canFire = -1f;
    private spawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("spawnManager").GetComponent<spawnManager>();
        if (_spawnManager ==  null )
        {
            Debug.Log("the spawn manager is null ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveMentCode();
         spawnLaser();
    }

    void moveMentCode() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");


        // video 24
        //  this.gameObject.transform.Translate(Vector3.up * 3.5f * VerticalInput * Time.deltaTime);
        // this.gameObject.transform.Translate(Vector3.right * 3.5f * horizontalInput * Time.deltaTime);

        // video 25
        Vector3 dir = new Vector3(horizontalInput, VerticalInput, 0);
        this.transform.Translate(dir * 3.5f * Time.deltaTime);

        // video 26 making restrictions to move the object only in box

        /*f (transform.position.y > 6.18f)
         {
             this.transform.position = new Vector3(transform.position.x, 0,0);
         }
         else if (transform.position.y <  -4f)
         {
             this.transform.position = new Vector3(transform.position.x, 0, 0);
         }*/
        if (transform.position.x > 13)
        {
            this.transform.position = new Vector3(0, transform.position.y, 0);

        }
        else if (transform.position.x < -13)
        {

            this.transform.position = new Vector3(0, transform.position.y, 0);

        }

        // video 28 for calmping 

        // we can also do this above thing in some manner of clamping but in clamp it cant go back to orignal position 

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 5.6f), 0);

    }

    void spawnLaser()
    {

        // video 33
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            canFire= Time.time + _fireRate;
            Instantiate(_laser, transform.position + new Vector3(0,.8f,0), Quaternion.identity);
            
        }
    }
    public void Damage()
    {
        _life -= 1;
        if (_life < 1)
        {
            _spawnManager.GameEnd();
            Destroy(this.gameObject);
        }
    }
    
}
