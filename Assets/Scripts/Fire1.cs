using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private GameObject eject;

    [SerializeField]
    private Transform ejectPos;


    private Vector2 lookDirection;
    private float lookAngle;
    public bool canFollow;

    public float offset;

    public Transform Weapon { get => weapon; set => weapon = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.simetricSkil = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.simetricSkil == false)
        {
            FollowMouse();
        }
        else if (playerMovement.simetricSkil == true)
        {
            FollowMouseSimetric();
        }

        if (Weapon.rotation.z <= 0)
        {
            playerMovement.DisRefletPlayer();
        }

        else
        {
            playerMovement.ReflectPlayer();
        }



    }

    public void FiringAmmo()
    {
        GameObject firedBullet = Instantiate(bullet, firePos.position, firePos.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = firePos.up * playerMovement.FireSpeed;

        ejection();
    }

    public void FollowMouse()
    {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg * 1/2;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f + offset);        
    }
    public void FollowMouseSimetric()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f + offset);
    }


    public void ejection()
    {
        GameObject firedEject = Instantiate(eject, ejectPos.position, firePos.rotation);
        firedEject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));

    }
}
