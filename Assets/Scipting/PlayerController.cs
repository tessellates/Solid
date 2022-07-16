using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float ms = 10f;
    public Transform movePoint;
    public LayerMask colliderMask;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, ms * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f )
        {
            var inputH = Input.GetAxisRaw("Horizontal");
            var inputV = Input.GetAxisRaw("Vertical");
            var newPostion = Vector3.zero + movePoint.position; // CSharp is a shit language so you can't deepcopy by default, C++>C#
            if ( Mathf.Abs(inputH) == 1f && inputV == 0f )
            {
                newPostion += new Vector3( inputH, 0f, 0f );
                var playerSprite = GetComponent<ResizeableSprite>();
                playerSprite.flipOnX( inputH == -1f );
            }
    
            if ( Mathf.Abs(inputV) == 1f  && inputH == 0f )
            {
                newPostion += new Vector3( 0f, inputV, 0f );
                //movePoint.position += new Vector3( 0f, inputV, 0f );
            }
            if ( !Physics2D.OverlapCircle( newPostion, 0.1f, colliderMask ) )
            {
                movePoint.position = newPostion;
            }
            
        }


    }
}
