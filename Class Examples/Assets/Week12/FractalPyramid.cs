using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalPyramid : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public float childScale;

    public int maxDepth;
    private int _depth;
    
    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        
        if (_depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private void Initialize(FractalPyramid parent, Vector3 direction, Quaternion orientation)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        childScale = parent.childScale;
        _depth = parent._depth + 1;
        
        var t = transform;
        t.parent = parent.transform;
        t.localScale = Vector3.one * childScale;
        t.localPosition = direction * (0.5f + 0.5f * childScale);
        t.localRotation = orientation;
    }
    
    private IEnumerator CreateChildren()
    {
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
        
        new GameObject("Fractal Child").AddComponent<FractalPyramid>()
            .Initialize(this, Vector3.up, Quaternion.identity);
            
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
        
        new GameObject("Fractal Child").AddComponent<FractalPyramid>()
            .Initialize(this, Vector3.right, Quaternion.Euler(0,0,-90));
            
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
        
        new GameObject("Fractal Child").AddComponent<FractalPyramid>()
            .Initialize(this, Vector3.left, Quaternion.Euler(0,0,90));
            
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
        
        new GameObject("Fractal Child").AddComponent<FractalPyramid>()
            .Initialize(this, Vector3.forward, Quaternion.Euler(90,0,0));
        
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
        
        new GameObject("Fractal Child").AddComponent<FractalPyramid>()
            .Initialize(this, Vector3.back, Quaternion.Euler(-90,0,0));
    }
}
