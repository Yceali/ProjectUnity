using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCreator : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private GameObject backGround;

    private float location;
    private int nextBG;
    // Start is called before the first frame update
    void Start()
    {
        nextBG = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DuplicateBg()
    {
        for (int i = 1; i < nextBG; i++)
        {
            location = playerMovement.transform.position.x + 25f * i;
            Instantiate(backGround, new Vector3(location, 4, 0), Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DuplicateBg();
            Destroy(this.GetComponent<Collider2D>());
            nextBG++;
        }
    }
}
