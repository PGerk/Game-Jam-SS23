using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaster : MonoBehaviour
{
    
    private Stack<GameObject> goblinStack;
    [SerializeField] GameObject goblinPrefab;

    private LevelController levelController;

    private void Awake()
    {
        this.levelController = FindObjectOfType<LevelController>();
        this.goblinStack = new Stack<GameObject>();
    }

    /// <summary>
    /// Gets Goblin from Stack or instantiate new one
    /// </summary>
    /// <returns>Inactive Goblin GameObject</returns>
    public GameObject GetNewGoblin()
    {
        this.levelController.AliveGoblins++;
        if (this.goblinStack.Count > 0)
            return this.goblinStack.Pop();
        
        GameObject newGoblin = Instantiate(this.goblinPrefab);
        newGoblin.SetActive(false);
        return newGoblin;
    }

    public void KillGoblin(GameObject goblin)
    {
        this.levelController.DiedGoblins++;
        goblin.SetActive(false);
        this.goblinStack.Push(goblin);
    }
}
