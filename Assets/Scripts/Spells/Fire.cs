using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask playerLayer;
    Vector3 fwd;
    Rigidbody rb;
    [SerializeField] float explosionRadius;
    [SerializeField] float pushBack;
    [SerializeField] float playerPushBack;
    [SerializeField] float damage;
    [SerializeField] float maxSize;
    [SerializeField] float up;
    GameObject explosion;
    [SerializeField] Rigidbody player;
    void Start()
    {
        fwd = Camera.main.transform.forward;
        rb = GetComponent<Rigidbody>();
        transform.rotation = Camera.main.transform.rotation;
        explosion = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        rb.velocity = fwd * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 7)
        {
            RaycastHit[] raycastHit = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.forward, maxSize, enemyLayer);
            if(raycastHit.Length > 0)
            {
                foreach(RaycastHit hit in raycastHit)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    hit.collider.attachedRigidbody.isKinematic = false;
                    hit.collider.GetComponent<BasicAI>().SetTimerNoKinematic(0.5f);
                    hit.collider.attachedRigidbody.AddForce(-(transform.position - hit.collider.transform.position).normalized * pushBack);
                    hit.collider.GetComponent<EnemyHealth>().Damage(damage);
                }
            }
            if(Physics.CheckSphere(transform.position, explosionRadius, playerLayer))
            {
                player.AddForce(-(transform.position - player.transform.position).normalized * playerPushBack);
                Debug.Log("player hit ");
            }
            explosion.transform.parent = null;
            explosion.SetActive(true);
            Destroy(explosion, 1);
            Destroy(this.gameObject);
        }
    }
}
