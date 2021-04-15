using UnityEngine;


namespace Ui
{
    public class CursorTrailView : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _position;

        public void Init()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _position = _camera.ScreenToWorldPoint(Input.mousePosition);
            _position.z = transform.position.z;
            transform.position = _position;
        }
    }
}
