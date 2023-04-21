using TMPro;
using UnityEngine;

public class MoutonsCounter : MonoBehaviour
{
    #region Public Members
    public static MoutonsCounter Instance;

    public Vector2Int m_gridSize;

    public Transform m_cell;
    public Transform m_cherifHead;

    public Transform[] m_transforms;
    public Transform[] m_buildingBlocks;

    public TextMeshProUGUI m_text;

    public bool m_isPirate;
    public bool m_isHot;
    #endregion


    #region Unity API

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        m_isPirate= false;
        m_isHot = false;
        int _cellCount = m_gridSize.x * m_gridSize.y;
        int _cellCurrentCount = 0; 

        m_transforms = new Transform[_cellCount];


        for (int x = 0; x < m_gridSize.x; x++)
        {
            for (int z = 0; z < m_gridSize.y; z++)
            {
                m_transforms[_cellCurrentCount] = Instantiate(m_buildingBlocks[Random.Range(0, m_buildingBlocks.Length)], new Vector3(x, 0, z), Quaternion.identity, transform);
                m_transforms[_cellCurrentCount].name = $"Cell: {m_transforms[_cellCurrentCount].position.x}, " +
                                                       $"{m_transforms[_cellCurrentCount].position.y}" +
                                                       $"{m_transforms[_cellCurrentCount].position.z}";
                _cellCurrentCount++;
            }
            
        }       

        
        _cherifInGame = Instantiate(m_cherifHead, new Vector3(m_gridSize.x/2, 1, m_gridSize.y/2), Quaternion.identity, transform);
        _cherifInGame.Rotate(90,0,0);
        FireAndWaterCheck(new Vector3(m_gridSize.x / 2, 1, m_gridSize.y / 2));
    }

    private void Update()
    {
        if (_cherifInGame.position.z < (m_gridSize.y - 1)  && Input.GetKeyDown(KeyCode.UpArrow))
        {
            FireAndWaterCheck(new Vector3(_cherifInGame.position.x, 0, _cherifInGame.position.z + 1));           
            _cherifInGame.position += new Vector3(0, 0, 1);                       
        }
        if (_cherifInGame.position.z > (m_transforms[m_gridSize.y - 1].position.z - m_gridSize.y + 1) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            FireAndWaterCheck(new Vector3(_cherifInGame.position.x, 0, _cherifInGame.position.z - 1));
            _cherifInGame.position += new Vector3(0, 0, -1);              
        }
        if (_cherifInGame.position.x > (m_transforms[0].position.x) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FireAndWaterCheck(new Vector3(_cherifInGame.position.x - 1, 0, _cherifInGame.position.z));
            _cherifInGame.position += new Vector3(-1, 0, 0);          
        }
        if (_cherifInGame.position.x < (m_transforms[m_transforms.Length-1].position.x) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            FireAndWaterCheck(new Vector3(_cherifInGame.position.x + 1, 0, _cherifInGame.position.z));
            _cherifInGame.position += new Vector3(1, 0, 0);      
        }
    }

    private void FireAndWaterCheck(Vector3 position)
    {
        foreach (Transform mouton in m_transforms)
        {
            if (mouton.tag == "Fire")
            {
                if (mouton.transform.position == position)
                {
                    m_text.text = "REEEEEEEE\n" +
                        "It burns!";
                    m_isHot = true;
                    m_isPirate = false;
                }
            }
            else if (mouton.tag == "Water")
            {
                if (mouton.transform.position == position)
                {
                    m_text.text = "Harr Harr\n" +
                        "I'm a Pirate Now";
                    m_isPirate = true;
                    m_isHot = false;
                }
            }
            else
            {
                if (mouton.transform.position == position)
                {
                    m_text.text = "Just Casually playing Saute-Mouton on some elemental moutons";
                    m_isPirate = false;
                    m_isHot= false;
                }
            }
        }
    }
    #endregion


    #region Private and Protected

    Transform _cherifInGame;

    #endregion
}
