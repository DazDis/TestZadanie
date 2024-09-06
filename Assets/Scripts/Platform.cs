using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _wallLeft;
    [SerializeField] private Transform _wallRight;
    private float _minPosition;
    private float _maxPosition;

    private void Awake()
    {
        _minPosition = _wallLeft.position.x + 2.5f;
        _maxPosition = _wallRight.position.x - 2.5f;

    }
    public void SetPosition(float posX)
    {
        transform.position = new Vector3(
                Mathf.Clamp(posX, _minPosition, _maxPosition),
                transform.position.y,
                transform.position.z
            );
    }

}
