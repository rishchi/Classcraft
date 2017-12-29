using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingCharacter : MonoBehaviour {

    public float timer;
    public int newtarget;
    public float speed;
    public Rigidbody rig;
    public UnityEngine.AI.NavMeshAgent nav;
    public Vector3 Target;
    public float myX;
    public float myZ;
    public float magnitudeTarget;
    
    public float zPos;

    // Use this for initialization
    void Start () {
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        rig = gameObject.GetComponent<Rigidbody>();
        NewTarget();

        

    }
	
	// Update is called once per frame
	void Update () {
       

    }

    public int currentHealth = 3;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    

    void NewTarget()
    {
        myX = gameObject.transform.position.x;
        myZ = gameObject.transform.position.z;
     
       
        float zPos = Random.Range(192, 321);

       Target = new Vector3(205, gameObject.transform.position.y, zPos);
        
        nav.speed=speed;
        nav.SetDestination(Target);


    }
   
}
