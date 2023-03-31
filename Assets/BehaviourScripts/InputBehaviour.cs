using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    public int PlayerNum;

    // Start is called before the first frame update
    void Start()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    //Update is called once per frame
    void Update()
    {
        if (PlayerNum == 1)
        {
            _moveBehaviour.SetMoveDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
            if (Input.GetKeyDown(KeyCode.W))
                _moveBehaviour.Jump();
        }

        if (PlayerNum == 2)
        {
            _moveBehaviour.SetMoveDirection(new Vector3(Input.GetAxisRaw("Horizontal2"), 0, 0));
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _moveBehaviour.Jump();
        }
    }
}