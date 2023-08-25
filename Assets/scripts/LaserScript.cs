using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveCapsule();
        destroyingLaser();
    }

    void moveCapsule()
    {
        this.transform.Translate(Vector3.up *Time.deltaTime * speed );
    }
    void destroyingLaser()
    {
        if( this.transform.position.y > 5f)
        {
            if ( this.transform.parent != null)
            {
                Destroy( this.transform.parent.gameObject );
            }

            Destroy(this.gameObject);
        }
    }
}
