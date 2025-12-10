using UnityEngine;

public class MoveLeftState : IBlockState
{
    public void Enter(BlockController block)
    {
        // opcional: iniciar animación/efecto
    }

    public void Exit(BlockController block)
    {
        // opcional: limpiar
    }

    public void Tick(BlockController block)
    {
        if (block == null) return;

        Vector3 target = block.startPosition + Vector3.right * block.leftOffset;
        block.transform.position = Vector3.MoveTowards(block.transform.position, target, block.speed * Time.deltaTime);

        if (Vector3.Distance(block.transform.position, target) < 0.01f)
        {
            block.SetState(block.moveRightState);
        }
    }
}
