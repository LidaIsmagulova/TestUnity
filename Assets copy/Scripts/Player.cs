using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private float speed = 5f;
    [SerializeField] private InputAction fire;
    [SerializeField] private GameObject[] lasers;

     private void OnEnable()
    {
        movement.Enable();
         fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }
    
    private void Update()
    {
        ProcessFire();
        Move();

    }

     private void ProcessFire()
    {
        if (fire.ReadValue<float>() > 0.5f)
        {
            foreach (var laser in lasers)
            {
                laser.SetActive(true);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                laser.SetActive(false);
            }
        }

    }

    private void Move()
    {
        float horizontalMovement=movement.ReadValue<Vector2>().x;
        float verticalMovement=movement.ReadValue<Vector2>().y;
        float horizontalThrow = horizontalMovement * Time.deltaTime * speed;
        float verticalThrow = verticalMovement * Time.deltaTime*speed;
        transform.localPosition += new Vector3(horizontalThrow, verticalThrow);
    }
}
