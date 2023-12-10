using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button_click : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetObject;
    public float zoomSpeed = 200f;
    public float returnSpeed = 200f;
    public float trueDistance = 100f;
    private Button button;
    public float delay = 2f;

    private Vector3 initialCameraPosition; // Начальная позиция камеры

    void Start()
    {
        // Сохраняем начальную позицию камеры при запуске
        initialCameraPosition = mainCamera.transform.position;
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        if (mainCamera != null && targetObject != null && movementCamera(initialCameraPosition))
        {
            Vector3 direction = targetObject.position - mainCamera.transform.position;

            StartCoroutine(ZoomIn(direction));
        }
    }


    IEnumerator ZoomIn(Vector3 direction)
    {

        float distance = direction.magnitude;

        while (distance > trueDistance)
        {
            mainCamera.transform.position += direction.normalized * Time.deltaTime * zoomSpeed;

            distance = (targetObject.position - mainCamera.transform.position).magnitude;

            yield return null;
        }

        // После завершения приближения возвращаемся в исходную позицию
        StartCoroutine(ReturnToInitialPosition());
    }

    IEnumerator ReturnToInitialPosition()
    {

        while (Vector3.Distance(mainCamera.transform.position, initialCameraPosition) > 0.1f)
        {
            // Плавное возвращение к начальной позиции
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, initialCameraPosition, returnSpeed * Time.deltaTime);

            yield return null;
        }

        // Устанавливаем точную позицию, чтобы избежать неточностей
        mainCamera.transform.position = initialCameraPosition;
    }

    public bool movementCamera(Vector3 initialCameraPosition)
    {
        return initialCameraPosition == mainCamera.transform.position;
    }
}
