using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class StageGenerate : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] StagePool pool;
    [SerializeField] GameObject Startpoint;
    [SerializeField] Transform[] lanePoints;
    [SerializeField] float tileLength = default;
    [SerializeField] float spawnDistance = default;
    [SerializeField] int rowsOnScreen = default;
    CellType[] previousRow;

    float spawnZ;
    float lastSpawnZ;
    int lastSafeLane;
    public enum CellType
    {
        Safe,
        Obstacle,
        Hole
    }

    void Start()
    {
        spawnZ = 0;
        lastSafeLane = lanePoints.Length / 2;

        for (int i = 0; i < rowsOnScreen; i++)
            SpawnRow();
    }
    private void Update()
    {
        Debug.Log(lastSpawnZ);
        Debug.Log(MathF.Abs(player.position.z) + spawnDistance);
        if (MathF.Abs(player.position.z - Startpoint.transform.position.z)+ spawnDistance > Mathf.Abs(lastSpawnZ))
        {
            SpawnRow();
        }
    }

    void SpawnRow()
    {

        CellType[] row = GenerateRowPattern();
        for (int i = 0; i < row.Length; i++)
        {
            Vector3 pos = lanePoints[i].position + Vector3.forward * spawnZ;

            switch (row[i])
            {
                case CellType.Safe:
                    pool.SpawnFromPool("Safe", pos, Quaternion.identity);
                    break;

                case CellType.Obstacle:
                    float r = UnityEngine.Random.value;
                    if (r < 0.5f)
                        pool.SpawnFromPool("Obstacle", pos, Quaternion.identity);
                    else
                        pool.SpawnFromPool("Obstacle2", pos, Quaternion.identity);
                    break;

                case CellType.Hole:
                    // ‰½‚à¶¬‚µ‚È‚¢
                    break;
            }
        }
        lastSpawnZ = spawnZ;
        spawnZ += tileLength;
    }
CellType[] GenerateRowPattern()
    {
        int laneCount = lanePoints.Length;
        CellType[] row = new CellType[laneCount];
        float safeLaneRandom = UnityEngine.Random.value;

        int safelaneMove;

        if (safeLaneRandom < 0.45f)
            safelaneMove = -1;
        else if (safeLaneRandom < 0.9f)
            safelaneMove = 1;
        else
            safelaneMove = 0;
        int nextSafeLane = lastSafeLane + safelaneMove;
        nextSafeLane = Mathf.Clamp(nextSafeLane, 1, 3);
        for (int i = 0; i < laneCount; i++)
        {
            bool isSafeZone =
               i == nextSafeLane ||
               i == nextSafeLane + 1;
            if (isSafeZone)
            {
                row[i] = CellType.Safe;
            }
            else
            {
                float r = UnityEngine.Random.value;

                if (r < 0.5f)
                    row[i] = CellType.Obstacle;
                else
                    row[i] = CellType.Hole;

                // cHole‹ÖŽ~
                if (previousRow != null && previousRow[i] == CellType.Hole)
                {
                    row[i] = CellType.Obstacle;
                }
            }
        }
        lastSafeLane = nextSafeLane;
        previousRow = row;
        return row;
    }
}
