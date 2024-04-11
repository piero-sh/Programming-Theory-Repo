using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPartsManager : MonoBehaviour
{
    public static GlassPartsManager Instance { get; private set; }
    
    [SerializeField]
    private GameObject glassPartModel;
    private Transform parent;
    private List<Rigidbody> rigidbodies;

    public void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        rigidbodies = new List<Rigidbody>();
    }

    public void Generate(Transform _transform)
    {
        parent = new GameObject().transform;
        parent.transform.position = _transform.position;
        parent.transform.rotation = _transform.rotation;
        parent.transform.localScale = Vector3.one;
        parent.gameObject.SetActive(false);

        float rowCount = Mathf.Floor(_transform.localScale.x / glassPartModel.transform.localScale.x);
        Vector3 startPosition = new Vector3(
            _transform.position.x - (rowCount * 0.5f * glassPartModel.transform.localScale.x), 
            _transform.position.y - (rowCount * 0.5f * glassPartModel.transform.localScale.x), 
            _transform.position.z - (rowCount * 0.5f * glassPartModel.transform.localScale.x)
        );
        for(int x = 0; x < rowCount; x++)
        {
            for(int y = 0; y < rowCount; y++)
            {
                for(int z = 0; z < rowCount; z++)
                {
                    Vector3 position = new Vector3(
                        startPosition.x + (x * glassPartModel.transform.localScale.x), 
                        startPosition.y + (y * glassPartModel.transform.localScale.x), 
                        startPosition.z + (z * glassPartModel.transform.localScale.x)
                    );
                    if(Vector3.Distance(position, _transform.position) >= _transform.localScale.x * 0.5f)
                    {
                        continue;
                    }
                    GameObject part = GameObject.Instantiate(glassPartModel, position, glassPartModel.transform.rotation, parent.transform);
                    rigidbodies.Add(part.GetComponent<Rigidbody>());
                }
            }
        }
        #if UNITY_EDITOR
        Debug.Log(rigidbodies.Count + " glass parts created");
        #endif
    }

    public void Activate(Transform _transform)
    {
        if(rigidbodies == null)
        {
            return;
        }
        
        parent.position = _transform.position;
        parent.gameObject.SetActive(true);

        for(int i = 0; i < rigidbodies.Count; i++)
        {
            rigidbodies[i].isKinematic = false;
            rigidbodies[i].AddForce(Vector3.down * 11f, ForceMode.VelocityChange);
        }
    }
}
