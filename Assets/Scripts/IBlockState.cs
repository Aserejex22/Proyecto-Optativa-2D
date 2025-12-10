using UnityEngine;

public interface IBlockState
{
    void Enter(BlockController block);
    void Exit(BlockController block);
    void Tick(BlockController block);
}
