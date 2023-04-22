using UnityEngine;

public class GameView : MonoBehaviour
{
    public float defaultSmoothness;
    public float stopSmoothness;
    public float currentSmoothness;

    public Transform target;
    public Transform menuPos;

    public Vector3 offset;
    Vector3 velocity;

    [HideInInspector] public Camera camera;

    Player player;

    void Awake()
    {
        camera = GetComponent<Camera>();
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        velocity = Vector3.zero;
        currentSmoothness = defaultSmoothness;
    }

    void LateUpdate()
    {
        target = player.transform;

        Vector3 point = camera.WorldToViewportPoint(target.position);
        Vector3 delta = new Vector3(target.position.x, 0) + offset - camera.ViewportToWorldPoint(
                                                                     new Vector3(0.5f, 0.5f, 0));
        Vector3 destination = transform.position + delta;

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity,
                                                                           currentSmoothness);
    }
}
