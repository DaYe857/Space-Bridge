using UnityEngine;

public class DragObject : MonoBehaviour {
    private Vector3 _offset;
    private float _zCoord;

    void OnMouseDown() 
    {
        // ��ȡ�����������Ұ�е����
        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        // ��������������������ĵ�ƫ��
        Vector3 mouseWorldPos = GetMouseWorldPos();
        _offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag() 
    {
        Vector3 newPos = GetMouseWorldPos() + _offset;
        transform.position = newPos; // ֱ�Ӹ���λ��
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _zCoord; // �ؼ���ע�����ֵ
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
