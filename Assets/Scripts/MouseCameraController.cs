using UnityEngine;
using System.Collections;

public class MouseCameraController : MonoBehaviour
{
    [SerializeField] Vector3 hit_position = Vector3.zero;
    [SerializeField] Vector3 current_position = Vector3.zero;
    [SerializeField] Vector3 camera_position = Vector3.zero;

    public float MaxY = 18;
    public float MinY = -18;

    public float MaxX = 14;
    public float MinX = -14;

    [SerializeField] bool canScroll;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canScroll = true;
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        if (Input.GetMouseButton(0) && canScroll)
        {
            current_position = Input.mousePosition;
            if (this.transform.position.y < MaxY && this.transform.position.y > MinY && this.transform.position.x > MinX && this.transform.position.x < MaxX)
            {
                LeftMouseDrag();
            }
        }

        if (this.transform.position.y > MaxY || this.transform.position.y < MinY)
        {
            if (this.transform.position.y > 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, MaxY - 0.1f, -10);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x, MinY + 0.1f, -10);
            }
            
        }

        if (this.transform.position.x > MaxX || this.transform.position.x < MinX)
        {
            if (this.transform.position.x > 0)
            {
                this.transform.position = new Vector3(MaxX - 0.1f, this.transform.position.y, -10);
            }
            else
            {
                this.transform.position = new Vector3(MinX + 0.1f, this.transform.position.y, -10);
            }

        }
    }

    void LeftMouseDrag()
    {
        current_position.z = hit_position.z = camera_position.y;

        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        direction = direction * -1;

        Vector3 position = camera_position + direction;

        transform.position = position;
    }
}