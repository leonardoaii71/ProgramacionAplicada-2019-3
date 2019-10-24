using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public Item itemPrefab;
    public Item powerup1;
    private int maxwidth = 12;
    private float BlocksMargin = 1f;
    private int rowsSpawned;
    public TextMeshPro roundtext;
    private List<Item> blocksSpawned = new List<Item>();

    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            GenerateRowofBlocks();
        }
    }

    public void GenerateRowofBlocks()
    {
        foreach (var block in blocksSpawned)
        {
            if (block != null)
            {
                if (block.wasHit)
                {
                    Destroy(block.gameObject);
                }
                block.transform.position += Vector3.down * BlocksMargin;
            }
        }

        for (int i = 0; i < maxwidth; i++)
        {
            var seed = UnityEngine.Random.Range(0, 100);
            if (seed <= 50)
            {
                var block = Instantiate(itemPrefab, GetPosition(i), Quaternion.identity);
                int count = UnityEngine.Random.Range(1, 10) > 2 ? rowsSpawned + 1 : rowsSpawned + UnityEngine.Random.Range(rowsSpawned + 1, rowsSpawned * 2);

                block.setCount(count);
                blocksSpawned.Add(block);
            }
            else if(seed >= 98)
            {
                var pwup = Instantiate(powerup1, GetPosition(i), Quaternion.identity);
                blocksSpawned.Add(pwup);
            }
        }
        rowsSpawned++;
        updateRoundText(rowsSpawned);
    }

    private void updateRoundText(int round)
    {
        this.roundtext.SetText(round.ToString());
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * BlocksMargin;
        return position;
    }
}
