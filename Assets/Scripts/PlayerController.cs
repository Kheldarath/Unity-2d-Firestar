using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls; 
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerControls = new PlayerControls(); //creates a new player control map instance for this object
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update() //good for getting movement?
    {
        PlayerInput();
    }

    private void FixedUpdate() //good for applying physics?
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        Debug.Log(movement.x);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + (movement * (moveSpeed * Time.fixedDeltaTime)));
    }

}
