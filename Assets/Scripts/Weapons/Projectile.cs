using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected GameManager gameManager;
    [SerializeField] private float maxVolume = 1f;
    protected AudioSource hitSound;
    public int damage;

    protected virtual void Awake()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        gameManager.NextRound();
    }

    public abstract void Fire(Vector2 start, Vector2 end);
}
