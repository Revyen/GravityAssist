using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class ShipControll : MonoBehaviour {


    public float movespeed;
    public float rotation;
    public float gravity;
    public float flamegrowfactor;
    public bool isLanded;
    public GameObject remains;
    public GameObject flame;
    public float MaxHP;
    public float HP;
    public int dmgModifier;
    public float MaxFuel;
    public float Fuel;
    public float FuelEfficiency;
    public float Altitude;
    public List<float> PartDmg;
    public bool Useable;

    protected Rigidbody2D rb2d;
    protected CircleCollider2D leftleg;
    protected CircleCollider2D rightleg;
    protected List<PolygonCollider2D> chassi;
    protected Vector2 velocitybeforeimpact;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("ShipControll Script is loaded");
        rb2d.gravityScale = gravity;
        leftleg = GetComponents<CircleCollider2D>()[0];
        rightleg = GetComponents<CircleCollider2D>()[1];
        chassi = new List<PolygonCollider2D>(GetComponents<PolygonCollider2D>());
        MaxHP = HP;
        MaxFuel = Fuel;
        Useable = true;
    }


    // Update is called once per frame
    void FixedUpdate () {
        if (Useable)
        {
            if (Input.GetButton("Fire1"))
            {
                if (rb2d.velocity.magnitude > 0)
                {
                    rb2d.velocity -= rb2d.velocity.normalized * 0.1f;
                    Fuel -= FuelEfficiency * 4 * Time.deltaTime;
                }
            }
            else
            {
                float Velocity = Input.GetAxis("Vertical");
                if (Velocity <= 0 || Fuel <= 0)
                {
                    Velocity = 0;
                    cutoffEngine();
                }
                if (Velocity > 0)
                {
                    if (Fuel > 0)
                    {
                        Fuel -= FuelEfficiency * Time.deltaTime;
                        igniteEngine();
                    }
                }
                if (Fuel >= 0)
                {
                    rb2d.AddRelativeForce(new Vector2(0f, Velocity * movespeed), ForceMode2D.Force);
                }
            }
            if (!isLanded)
            {
                Fuel -= FuelEfficiency / 10 * Time.deltaTime;
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                rb2d.angularVelocity = 0;
            }
            rb2d.transform.Rotate(0f, 0f, Input.GetAxis("Horizontal") * rotation * Time.fixedDeltaTime * (-1));
        }

    }

    private void LateUpdate()
    {
        velocitybeforeimpact = rb2d.velocity;
        RaycastHit2D hit = Physics2D.Raycast(rb2d.position, new Vector2(0, -1),Mathf.Infinity,1<<8);
        Altitude = (hit.distance <= 0) ? 0 : hit.distance - 0.5f;
        
    }


    void igniteEngine()
    {
        flame.GetComponent<SpriteRenderer>().enabled = true;
        flame.GetComponentInChildren<ParticleSystem>().enableEmission = true;

        Transform t = flame.transform;
        if (t.localScale.x < 0.9)
        {
            t.localScale = new Vector3(t.localScale.x + flamegrowfactor, t.localScale.x + flamegrowfactor * 2, 0f);
        }
    }
    void cutoffEngine()
    {
        if (isLanded || Fuel <= 0)
        {
            flame.GetComponent<SpriteRenderer>().enabled = false;
            flame.GetComponentInChildren<ParticleSystem>().enableEmission = false;
        }
        Transform t = flame.transform;
        if (t.localScale.x > 0.4)
        {
            t.localScale = new Vector3(t.localScale.x - flamegrowfactor, t.localScale.x - flamegrowfactor * 2, 0f);
        }
    }
    void explodeShip()
    {
        GameObject debris = Instantiate(remains, transform.position, transform.rotation);
        debris.GetComponent<Debris_Controller>().parentForce = rb2d.velocity;
        Destroy(gameObject);
        Destroy(this);
    }

    #region OnCollision
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        //Debug.Log(coll.gameObject.tag);
        if (collisionChassi(coll))
        {
            float dmg = (int)Mathf.Pow(coll.relativeVelocity.magnitude*5 / dmgModifier, 2);
            PartDmg[getColliderChassiIndex(coll)] -= dmg / MaxHP / 0.25f;
            if(PartDmg[getColliderChassiIndex(coll)] <= 0)
            {
                explodeShip();
                return;
            }
            if(PartDmg[getColliderChassiIndex(coll)] <= 0.5)
            {
                Debug.Log(string.Format("DMG-Taken: {0}", dmg * 2));
                HP -= dmg * 2;
                
            }
            else
            {
                Debug.Log(string.Format("DMG-Taken: {0}", dmg));
                HP -= dmg;
            }
        }
        if(coll.relativeVelocity.magnitude >= dmgModifier)
        {
            float dmg = (int)Mathf.Pow(coll.relativeVelocity.magnitude*5 / dmgModifier,2);
            HP -= dmg;
        }
        if (coll.gameObject.tag == "Ground")
        {
            if(Fuel <= 0)
            {
                explodeShip();
                return;
            }
            HP -= dmgModifier;
        }
        if (HP <= 0)
        {
            explodeShip();
            return;
        }
        if (coll.gameObject.tag == "Landable")
        {
            if (leftleg.IsTouching(coll.collider) && rightleg.IsTouching(coll.collider))
                isLanded = true;
        }
        
        
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Landable")
        {
            isLanded = false;
        }
    }

    bool collisionChassi(Collision2D coll)
    {
        foreach(PolygonCollider2D p in chassi)
        {
            if (p.IsTouching(coll.collider))
            {
                return true;
            }

        }
        return false;
    }

    int getColliderChassiIndex(Collision2D coll)
    {
        int i = 0;
        foreach (PolygonCollider2D p in chassi)
        {
            if (p.IsTouching(coll.collider))
            {
                return i;
            }
            i++;
        }
        return -1;
    }
#endregion
}
