using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class movementScript : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private GameObject _tripleLaser;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int _life = 3;
    [SerializeField] private int _speedOfPlayer = 3;
    private float canFire = -1f;
    private SpawningManager _spawniingManager;
    public bool _enableTripleFire = false;
    public bool _enableSpeed= false;
    public bool _isShieldActive= false;
    public GameObject shieldVisualizer;
    // Start is called before the first frame update
    void Start()
    {
        _spawniingManager = GameObject.Find("SpawnManager").GetComponent<SpawningManager>();
        if (_spawniingManager ==  null )
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
        this.transform.Translate(dir * _speedOfPlayer * Time.deltaTime);

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
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire && _enableTripleFire)
        {
            
            canFire= Time.time + _fireRate;
            Instantiate(_tripleLaser, transform.position , Quaternion.identity);
            
        }
       
        else if ((Input.GetKeyDown(KeyCode.Space) && Time.time > canFire))
        {
            canFire = Time.time + _fireRate;
            Instantiate(_laser, transform.position + new Vector3(0, .8f, 0), Quaternion.identity);
            
        }

    }
    public void Damage()
    {
        if(_isShieldActive)
        {
            _isShieldActive= false;
            shieldVisualizer.SetActive(false);
            return;
        }
        _life -= 1;
        if (_life < 1)
        {
            _spawniingManager.GameEnd();
            Destroy(this.gameObject);
        }
    }
    public void EnableTripleShot()
    {
        _enableTripleFire = true;
        StartCoroutine(TripleShotTimer());
    }
    IEnumerator TripleShotTimer()
    {
        //Debug.Log("waiting for making close triple shot");
        yield return new WaitForSeconds(5f);
        _enableTripleFire = false;
    }
    public void EnhanceSpeed()
    {
        _enableSpeed = true;
        _speedOfPlayer += 3;
        StartCoroutine(SpeedTimer());
    }
    IEnumerator SpeedTimer()
    {
        //Debug.Log("waiting for making close triple shot");
        
        yield return new WaitForSeconds(4f);
        _speedOfPlayer = 3;
        _enableSpeed = false;
    }
    public void activeShield()
    {
        _isShieldActive = true;
        shieldVisualizer.SetActive(true);
    }
    public void UpdateScore()
    {

    }

}
