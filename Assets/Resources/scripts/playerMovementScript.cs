using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{


    public float moveSpeed = 10;
    public int jumpForce = 200;

    private Plane raycastPlane;
    private bool willJump;
    private float distToGround;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v0.1");
        this.createPlane();
        willJump = false;

        distToGround = GetComponent<Collider>().bounds.extents.y * 1.05f;

        anim = GetComponentInChildren<Animator>();

        anim.SetInteger("AnimIndex", 4);

    }

    private void createPlane()
    {
        raycastPlane = new Plane(new Vector3(0, 1, 0), this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<PhotonView>().isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }
        

        //handle input
        Vector3 curPos = transform.position;
        anim.SetInteger("AnimIndex", 4);

        if (Input.GetButton("up"))
        {
            curPos.x += moveSpeed * Time.deltaTime;
            anim.SetInteger("AnimIndex", 3);
        }
        if (Input.GetButton("down"))
        {
            curPos.x -= moveSpeed * Time.deltaTime;
            anim.SetInteger("AnimIndex", 3);
        }
        if (Input.GetButton("left"))
        {
            curPos.z += moveSpeed * Time.deltaTime;
            anim.SetInteger("AnimIndex", 3);
        }
        if (Input.GetButton("right"))
        {
            curPos.z -= moveSpeed * Time.deltaTime;
            anim.SetInteger("AnimIndex", 3);
        }

        if (Input.GetButtonDown("jump") && isGrounded())
        {
            willJump = true;

        }
        //apply movement
        transform.position = curPos;

        //adjust plane for raycasting
        raycastPlane.SetNormalAndPosition(new Vector3(0, 1, 0), this.transform.position);

        //change rotation according to mouse position
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (raycastPlane.Raycast(ray, out distance)) this.transform.LookAt(ray.GetPoint(distance));
    }

    void FixedUpdate()
    {
        if(willJump)
        {
            //anim.SetInteger("AnimIndex", QuerySDMecanimController.QueryChanSDAnimationType.);
            willJump = false;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}