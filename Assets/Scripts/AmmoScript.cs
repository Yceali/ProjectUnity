using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField]
    private float ammoTime = 1;
    [SerializeField]
    private GameTime gameTime;

    private bool canSlow;


    // Start is called before the first frame update
    void Start()
    {
        gameTime = GameObject.Find("GameManager").GetComponent<GameTime>();
        canSlow = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoTime -= Time.deltaTime * 8;

        if (ammoTime < 0 && gameTime.MyGameMode && canSlow)
        {
            SlowSelf();
            ammoTime = 0;
        }
    }

    public void SlowSelf()
    {  
        GetComponent<Rigidbody2D>().AddForce(transform.up * -800f);
        canSlow = false;
    }
}
