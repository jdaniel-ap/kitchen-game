using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    public static Player Instance {get; private set;}
    public event EventHandler OnClearCounterChange;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private PlayerInput playerInput;
    private bool isWalking;
    private Vector3 lastMoveDir;
    private CleanCounter selectedCounter;
    public CleanCounter activeSelectedCounter;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        OnClearCounterChange += (object sender, System.EventArgs e) => activeSelectedCounter = selectedCounter;
        playerInput.OnInteraction += GameInput_OnInteraction;
    }

    private void GameInput_OnInteraction(object sender, System.EventArgs e) {
        if(selectedCounter != null) {
            selectedCounter.Interact();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }


    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction() {
        Vector2 inputVector =  playerInput.GetPlayerInputNormalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float interactDistance = 2f;

        if(moveDir != Vector3.zero) {
            lastMoveDir = moveDir;
        }

        if(Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit, interactDistance)) {

            if(raycastHit.transform.TryGetComponent(out CleanCounter cleanCounter)) {
                if(selectedCounter != cleanCounter) {
                    selectedCounter = cleanCounter;

                    OnClearCounterChange?.Invoke(cleanCounter, EventArgs.Empty);
                } 
            } else {
                selectedCounter = null;
                OnClearCounterChange?.Invoke(null, EventArgs.Empty);
            }
        } else {
            selectedCounter = null;
            OnClearCounterChange?.Invoke(null, EventArgs.Empty);
        }
    }

    private void HandleMovement() {
        Vector2 inputVector =  playerInput.GetPlayerInputNormalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if(!canMove) {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if(canMove) {
                moveDir = moveDirX.normalized;
            } else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if(canMove) {
                    moveDir = moveDirZ.normalized;
                } else {
                    // not move
                }

            }
        }

        if(canMove) {
            transform.position += moveDir * moveDistance;
        }

        float rotateSpeed = 10f;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

}
