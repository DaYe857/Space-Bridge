using UnityEngine;

public class DragObject : MonoBehaviour {
    private Vector3 _offset;
    private float _zCoord;

    void OnMouseDown() 
    {
        // 获取物体在相机视野中的深度
        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        // 计算鼠标点击点与物体中心的偏移
        Vector3 mouseWorldPos = GetMouseWorldPos();
        _offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag() 
    {
        Vector3 newPos = GetMouseWorldPos() + _offset;
        transform.position = newPos; // 直接更新位置
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _zCoord; // 关键：注入深度值
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
