using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float turnSpeed = 8f;

    void MouseRotation()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        //// 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;



        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(0, yRotate, 0);

        //float yRotateSize = Input.GetAxis("Mouse X");

        //Debug.Log(yRotateSize);
    }
    private void MovePlayer()
    {

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //Debug.Log("Horizontal" + xInput);

        float xSpeed = xInput * playerSpeed;
        float zSpeed = zInput * playerSpeed;

        Vector3 speed = player.transform.TransformDirection(new Vector3(xSpeed, 0f, zSpeed));
        player.velocity = speed;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //MouseRotation();
        MovePlayer();
    }

    public void SetDie()
    {
        gameObject.SetActive(false);
    }
}
