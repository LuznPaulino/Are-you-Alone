using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Added engine features
using UnityEngine.AI; // randomized spawning and movement
using UnityEngine.SceneManagement; // next 

public class EnemyBehavior : MonoBehaviour
{
    private Transform myTransform;
    public GameObject target;
    public float attackDistance;
    public float spotDistance;
    public float speed;

    public float rateOfAttack;
    private float nextAttackTime;
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        nextAttackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(myTransform.position, target.transform.position);
        if (distance <= attackDistance)
        {
            // Attack animation if we have time to add in
            myTransform.LookAt(target.transform);
            myTransform.position = Vector3.MoveTowards(myTransform.position, target.transform.position, speed * Time.deltaTime);

            if(Time.time > nextAttackTime)
            {
                // player will have 3 iteration before they actually die
                GameControl.control.lives -= 1;
                nextAttackTime = Time.time + rateOfAttack;
                if(GameControl.control.lives <= 0)
                {
                    // Slap into Lose Scene
                    SceneManager.LoadScene(2); 

                }
            }
        }    
    }
}
