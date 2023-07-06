using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassing : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float wallPassSpeed = 5f;
    public float wallPassDuration = 1f;
    public LayerMask wallLayer;

    private bool isWallPassing = false;
    private float wallPassTimer = 0f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isWallPassing = true;
            wallPassTimer = wallPassDuration;
            gameObject.layer = LayerMask.NameToLayer("Ghost");
        }

        if (isWallPassing)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * wallPassSpeed * Time.deltaTime);
            wallPassTimer -= Time.deltaTime;
            if (wallPassTimer <= 0f)
            {
                isWallPassing = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
    }
}
