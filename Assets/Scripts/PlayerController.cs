using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float movementSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    public int countToWin;
    public int foodCount;
    
    



    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }

    private void FixedUpdate()
    {
        Move();
        
        
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);  
    }

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.CompareTag("Food")){
            print("I FOUND SOME FOOD!");
            Destroy(collision.gameObject);
            foodCount += 1;
            
            if(foodCount == countToWin && !gameManager.lastLevel)
            {
                Debug.Log("I GOT ALL OF THE FOOD!");
                gameManager.Win();       
            }
            else if(foodCount == countToWin && gameManager.lastLevel)
            {
                gameManager.WinGame();
            }

            }


        }

    }

