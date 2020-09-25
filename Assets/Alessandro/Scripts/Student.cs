using UnityEngine;

public class Student : MonoBehaviour
{
    //[SerializeField] private NavMeshAgent navAgent;
    private Camera cam;

    private Spawner spawn;
    private Score score;

    private Vector4 my_alpha = new Vector4(0f, 1.85f, 0f, 0.05f);
    private Vector4 m_color;

    private bool Selected = false;
    private bool gotItRight = false;

    public float coolDown = 2.0f;
    private float firstClick = 0.0f;
    private float distance = 0.0f;
    float count = 0;

    public string correctLocation;

    private Vector3 newDestination = Vector3.zero;
    [SerializeField] public int ID;

    private void Reset()
    {
        Selected = false;
        gotItRight = false;
        firstClick = 0.0f;
        GetComponentInChildren<Renderer>().material.SetFloat("_Outline", 0.0f);
        GetComponentInChildren<Renderer>().material.SetColor("_OutlineColor", m_color);
        m_color = GetComponentInChildren<Renderer>().material.GetVector("_OutlineColor");
        newDestination = Vector3.zero;
        transform.position = new Vector3(1.58f, 0.1f, 7.3f);
    }

    private void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
        score = GameObject.FindObjectOfType<Score>();
        spawn = GameObject.FindObjectOfType<Spawner>();
    }

    public bool IsSelected()
    {
        return Selected;
    }

    private void OnMouseDown()
    {
        if (!Selected && !gotItRight)
        {
            GetComponentInChildren<Renderer>().material.SetFloat("_Outline", 1.5f);
            GetComponentInChildren<Renderer>().material.SetColor("_OutlineColor", my_alpha);
            Selected = true;
        }
        else
        {
            GetComponentInChildren<Renderer>().material.SetFloat("_Outline", 0.0f);
            GetComponentInChildren<Renderer>().material.SetColor("_OutlineColor", m_color);
            Selected = false;
        }
    }

    private void PlayerController()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (firstClick <= 0.0f && Input.GetMouseButton(0))
        {
            firstClick = coolDown;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                newDestination = hit.point;

                GetComponent<AI_Student>().SetTarget(newDestination);
                Debug.Log(hit.collider.name);
                if (hit.collider.name == correctLocation && !gotItRight)
                {
                    score.AddScore(20);
                    gotItRight = true;
                    count = 2.0f;
                }
                else if (correctLocation == "Lab" && (hit.collider.name == "Lab1" || hit.collider.name == "Lab2") && !gotItRight)
                {
                    score.AddScore(20);
                    gotItRight = true;
                    count = 2.0f;
                }
            }
        }
        distance = Vector3.Distance(transform.position, newDestination);
    }

    // Update is called once per frame
    private void Update()
    {
        
        count -= Time.deltaTime;
        firstClick -= Time.deltaTime;

        if (Selected)
        {
            PlayerController();
        }
        if (distance <= 1.23f && gotItRight)
        {
            spawn.Respawn1(ID);
            Destroy(gameObject);
        }
        if (gotItRight && count <= 0.0f)
        {
            spawn.Respawn1(ID);
            Destroy(gameObject);
        }
    }
}