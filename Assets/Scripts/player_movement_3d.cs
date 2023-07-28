using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_3d : MonoBehaviour
{
    private float ray_lenght;
    public LayerMask ground;
    public bool is_on_ground;

    public float move_speed = 5.0f;
    public float rotation_speed;
    public float jump_force;
    public float vertical_speed;

    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController characterController;
    private Animator animator;

    public Transform camera_transform;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        ray_lenght = 0.3f;
        rotation_speed = 2.0f;
        jump_force = 7.5f;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * ray_lenght, Color.red);
        is_character_on_floor();

        // Player movement
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        // Camera Movement
        Vector3 forward = camera_transform.forward;
        Vector3 right = camera_transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move_direction = forward * move_vertical + right * move_horizontal;
        is_character_moving(move_direction);
        // mover el personaje mientras esta tocando el piso
        characterController.Move(move_direction * move_speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && is_on_ground)
        {
            vertical_speed = jump_force;
        }

        if (move_direction != Vector3.zero)
        {
            Quaternion to_rotation = Quaternion.LookRotation(move_direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, to_rotation, rotation_speed * Time.deltaTime);
        }
        // Gravedad
        vertical_speed += Physics.gravity.y * Time.deltaTime;
        // movimiento vertical 
        Vector3 vertical_movement = new Vector3(0.0f, vertical_speed, 0.0f);
        // mover character controller
        characterController.Move(vertical_movement * Time.deltaTime);
    }

    public void is_character_on_floor()
    {
        if (Physics.CheckSphere(groundCheck.position, ray_lenght, groundMask)) 
        {
            animator.SetBool("on_ground", true);
            is_on_ground = true;
        }
        else
        {
            animator.SetBool("on_ground", false);
            is_on_ground = false;
        }
    }

    public void is_character_moving(Vector3 movimiento)
    {
        if (movimiento != Vector3.zero)
        {
            animator.SetBool("on_move", true);
        }
        else
        {
            animator.SetBool("on_move", false);
        }
    }


    public void is_character_out_map()
    {
        if (Physics.CheckSphere(groundCheck.position, ray_lenght, groundMask))
        {
            // Regresar al ultimo save point

            // Hacer daño
        }
    }
}
