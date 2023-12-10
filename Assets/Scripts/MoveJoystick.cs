using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystick : MonoBehaviour
{
    public Camera mainCamera;
    public Joystick joystick; // ������ �� ��������� ���������
    public float rotateSpeed = 15;
    private Vector3 initialCameraPosition; // ��������� ������� ������
    void Start()
    {
        initialCameraPosition = mainCamera.transform.position;
    }

    private void Update()

    {
        float moveHorizontal = joystick.Horizontal; // �������� �������� �������������� ��� �� ���������
        float moveVertical = joystick.Vertical; // �������� �������� ������������ ��� �� ���������

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // ������� ������ �������� �� ������ ���������� �������� ����

        // �������� ��������� � ������� ��� ��������
        if (movement != Vector3.zero && initialCameraPosition == mainCamera.transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement); // ��������� ������� ������� � ������� ��������
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); // ������ ������������ �������� � ������� �������� ��������
        }
    }
}