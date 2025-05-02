using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>(); // เพิ่มบรรทัดนี้
    }

    private void Update()
    {
        if (hit) return;

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        rb.velocity = Vector2.zero; // หยุดการเคลื่อนที่

        if (collision.tag == "Enemy")
            collision.GetComponent<Health>()?.TakeDamage(1);
    }

    // ใช้สำหรับเคลื่อนที่แบบวิถีโค้ง
    public void Launch(Vector2 velocity)
    {
        gameObject.SetActive(true);
        hit = false;
        lifetime = 0;
        boxCollider.enabled = true;

        rb.velocity = velocity;

        // หมุนตามทิศถ้าต้องการ (เลือกทำ)
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(velocity.x) != Mathf.Sign(localScaleX))
            localScaleX = -localScaleX;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    // ใช้สำหรับเคลื่อนที่แบบเส้นตรง (เดิม)
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}