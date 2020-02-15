using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float fireSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed;

    public float JumpSpeed { get => jumpSpeed; }
    public float MoveSpeed { get => moveSpeed; }
    public float FireSpeed { get => fireSpeed; set => fireSpeed = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
