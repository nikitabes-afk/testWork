using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public button_click buttonClickScript;
    public Camera mainCamera;
    public GameObject gameobject;
    private Button button;
    private int rotate = 15; // ���� ��������� �������
    private int rotationIncrement = 15; // ���������� ���� ��� ������ �������

    private Vector3 initialCameraPosition; // ��������� ������� ������

    void Start()
    {
        initialCameraPosition = mainCamera.transform.position;

        button = GetComponent<Button>();

        if (button != null )
        {
            button.onClick.AddListener(OnButton);
        }
    }

    public void OnButton()
    {
        if(initialCameraPosition == mainCamera.transform.position)
        {
            gameobject.transform.rotation = Quaternion.Euler(0, rotate, 0);
            rotate += rotationIncrement; // ����������� ���� ��� ���������� �������
        }
    }
}
