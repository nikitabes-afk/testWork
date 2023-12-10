using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystick : MonoBehaviour
{
    public Camera mainCamera;
    public Joystick joystick; // Ссылка на компонент джойстика
    public float rotateSpeed = 15;
    private Vector3 initialCameraPosition; // Начальная позиция камеры
    void Start()
    {
        initialCameraPosition = mainCamera.transform.position;
    }

    private void Update()

    {
        float moveHorizontal = joystick.Horizontal; // Получаем значение горизонтальной оси от джойстика
        float moveVertical = joystick.Vertical; // Получаем значение вертикальной оси от джойстика

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // Создаем вектор движения на основе полученных значений осей

        // Вращение персонажа в сторону его движения
        if (movement != Vector3.zero && initialCameraPosition == mainCamera.transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement); // Вычисляем целевой поворот в сторону движения
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); // Плавно поворачиваем персонаж в сторону целевого поворота
        }
    }
}