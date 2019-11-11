using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellularAutomata : MonoBehaviour
{
    public GameObject prefab;
    public int columns;
    public int rows;
    public bool randGen1;
    [Range(0f,1f)]
    public float speed = 0.1f;
    public int[] ruleset = {0,1,1,1,1,0,1,1};
    
    private int[,] _generations;
    private GameObject[,] cells;
    private int _delay = 1;
    
    void Start()
    {
        _generations = new int[rows, columns];
        cells = new GameObject[rows,columns];
        
        
        GenerateGrid();

        for (var i = 0; i < columns; i++)
        {
            _generations[0, i] = randGen1 ? Random.Range(0, 2) :　i == columns / 2 ? 1 : 0;
            cells[0,i].GetComponent<Renderer>().material.color = _generations[0, i] == 0 ? Color.white : Color.black;
        }

        StartCoroutine(NextGenCr());

    }

    void GenerateGrid()
    {
        for (var i = 0; i < columns; i++)
        {
            for (var j = 0; j < rows; j++)
            {
                var cell = Instantiate(prefab, transform);
                cell.transform.Translate(-columns / 2f + i, rows / 2f - j, 0);
                cells[j, i] = cell;
            }
        }
    }
    
    int Rules(int a, int b, int c)
    {
        var s = "" + a + b + c;
        var index = Convert.ToInt32(s,2);
        return ruleset[index];
    }

    void NextGen(int g)
    {
        var message = "";
        for (var i = 0; i < columns; i++)
        {
            var previous = g > 0 ? g - 1 : rows-1;
            var left = i > 0 ? _generations[previous, i - 1] : 0;
            var center = _generations[previous, i];
            var right = i < columns-1 ? _generations[previous, i + 1] : 0;

            var next = Rules(left, center, right);

            _generations[g, i] = next;

            message += next;
            
            cells[g,i].GetComponent<Renderer>().material.color = _generations[g, i] == 0 ? Color.white : Color.black;
        }
//        Debug.Log(message);
    }

    IEnumerator NextGenCr()
    {
        for (var i = 0; i < rows; i++)
        {
            yield return new WaitForSeconds(speed);
            NextGen(_delay);
            _delay++;
            if (_delay >= rows) _delay = 0;
        }

        StartCoroutine(nameof(NextGenCr));
    }

}
