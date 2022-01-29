
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int points = -200;

    public Movement movement;

    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened fright { get; private set; }
    public GhostBehaviour inicialBehaviour;
    public Transform target;
    
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.fright = GetComponent<GhostFrightened>();
    }
    private void Start()
    {
       
        ResetState();
    }
    public void ResetState()
    {
       
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        this.fright.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if(this.home != inicialBehaviour)
        {
            this.home.Disable(); 
        }

        if(this.inicialBehaviour != null)
        {
            this.inicialBehaviour.Enable(); 
        }
    }

    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.fright.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else { FindObjectOfType<GameManager>().PacmanEaten(); }
        }
    }
}
