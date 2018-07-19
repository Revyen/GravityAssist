using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    public float MovementSpeed;
    public bool isClimbing;
    public bool Useable;

    private bool FacingRight;
    private Animator thisAnimator;
    // Use this for initialization
	void Start () {
        Useable = false;
        FacingRight = true;
        thisAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Useable)
        {
            float movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().position += new Vector2(movement * Time.deltaTime * MovementSpeed, 0f);
            Flip(movement);
            thisAnimator.SetFloat("Speed", Mathf.Abs(movement));
        }
	}

    private void Flip(float horizontal)
    {
        if((horizontal > 0 && !FacingRight) || (horizontal < 0 && FacingRight))
        {
            FacingRight = !FacingRight;
            Vector3 tmp = transform.localScale;
            tmp.x *= -1;
            transform.localScale = tmp;
        }
    }
}
