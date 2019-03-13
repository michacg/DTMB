using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* TO DO: 
 * 1. Implement randomized speed on rigidBody velocity. (Done)
 * 2. Change the use of "top" GameObject to using 
 *    OnTriggerEnter. (Done)
 * 3. Add Colliders on boba balls.
 * 4. Detect boba ball collisions.
 */

public class Straw : MonoBehaviour
{
	public GameObject lowerBound;
	public GameObject upperBound;
    public GameObject player;

	public float interval;
    public float strawBound;

	private float left_x;
	private float right_x;
	private float lower_y;
	private float upper_y;

	private float timeElapsed;
    private float speed;
    private float rand_time;

	private Vector2 fallDirection;
    private Vector2 sideDirection;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0.0f;

        float width = GetComponent<Renderer>().bounds.size.x;
    	left_x = player.transform.position.x - strawBound;
        right_x = player.transform.position.x + strawBound;
        lower_y = lowerBound.transform.position.y;
    	upper_y = upperBound.transform.position.y;
        
    	fallDirection = new Vector2(0, 0);
        sideDirection = Vector2.right;
    	timeElapsed = 0;
        transform.position = new Vector2(transform.position.x, upper_y);
    }

    // Update is called once per frame
    void Update()
    {
    	timeElapsed += Time.deltaTime;

        if (LevelManager.instance.isGameOver)
        {
            fallDirection = new Vector2(0,0);
        }

        else
        {
            if (player != null)
            {
                right_x = player.transform.position.x + 1;
                left_x = player.transform.position.x - 1;
            }        

            // straw is below the cup
            if (this.transform.position.y <= lower_y)
        	{
                if (fallDirection != Vector2.up)
                {
                    fallDirection = Vector2.up;
                    rand_time = Random.Range(1, interval - timeElapsed);
                    speed = (upper_y - lower_y) / rand_time;
                }

            }
            
            // straw is completely out of the cup
        	else if (this.transform.position.y >= upper_y)
        	{
        		if (timeElapsed >= interval)
        		{
                    MoveSide();

                    if (fallDirection != Vector2.down)
                    {   
                        fallDirection = Vector2.down;
        			    timeElapsed = 0;
                        rand_time = Random.Range(0.5f, 1.0f);
                        speed = (upper_y - lower_y) / rand_time;
                    }
                }

        		else
        		{
                    MoveSide();
        			fallDirection = new Vector2(0, 0);
        		}
        	}
        }

        MoveDown();
    }

    void MoveDown()
    {

        if (LevelManager.instance.isSmallMode)
            GetComponent<Rigidbody2D>().velocity = fallDirection * speed * Random.Range(1.25f,1.75f);
        else
            GetComponent<Rigidbody2D>().velocity = fallDirection * speed;
    }

    void MoveSide()
    {
        rand_time = Random.Range(0.05f,2);
        if (LevelManager.instance.isSmallMode)
            speed = ((right_x - left_x) / rand_time) * Random.Range(1.5f, 2.5f);
        else
            speed = (right_x - left_x) / rand_time;

        if (this.transform.position.x >= right_x)
        {
            sideDirection = Vector2.left;
        }

        if (this.transform.position.x <= left_x)
        {
            sideDirection = Vector2.right;
        }

        this.transform.Translate(sideDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boba"))
        {
            Destroy(collider.gameObject);
            StartCoroutine(Freeze());
        }

        else if (collider.CompareTag("Player"))
        {
            LevelManager.instance.isGameOver = true;
            Destroy(collider.gameObject);
        }
    }

    IEnumerator Freeze()
    {
        fallDirection = new Vector2(0, 0);
        yield return new WaitForSeconds(1.5f);
        fallDirection = Vector2.up;
    }

    public void GameOverFreeze()
    {
        fallDirection = new Vector2(0,0);
    }
}
