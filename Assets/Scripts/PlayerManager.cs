using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : Singleton<PlayerManager>
{
    public float speed;
    private Vector2 move;
    [SerializeField] CharacterController characterController;

    public GameObject objectInHands;
    public Transform handsPos;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y);

        characterController.Move(movement * speed * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.5f);
        }
        Gravity();
    }

    void Gravity()
    {
        Vector3 movement = new Vector3(0, -5, 0);
        characterController.Move(movement * Time.deltaTime);
    }
}
