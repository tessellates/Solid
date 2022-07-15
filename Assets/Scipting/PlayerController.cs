using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float ms = 5f;
    public Transform movePoint;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, ms * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .005f )
        {
            var inputH = Input.GetAxisRaw("Horizontal");
            var inputV = Input.GetAxisRaw("Vertical");
            
            if ( Mathf.Abs(inputH) == 1f && inputV == 0f )
            {
                movePoint.position += new Vector3( inputH, 0f, 0f );
            }
    
            if ( Mathf.Abs(inputV) == 1f  && inputH == 0f )
            {
                movePoint.position += new Vector3( 0f, inputV, 0f );
            }    
        }


    }
}
