using UnityEngine;

public class MiningTool : MonoBehaviour
{
    [SerializeField] private float _miningDistance;
    [SerializeField] private LayerMask _diamons;
    [SerializeField] private Animator _tool;

    [SerializeField] private ToolType _toolType;

    private const string Mine = "Mine";

    private enum ToolType
    {
        Drill,
        circularSaw
    }

    public MinedCristal TryMine()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up, out hit, _miningDistance, _diamons))
        {
            if (_toolType == ToolType.circularSaw && hit.collider.TryGetComponent(out RedCristal redCristal))
            {
                return MineCristal(redCristal);
            }

            if (_toolType == ToolType.Drill && hit.collider.TryGetComponent(out BlueCristal blueCristal))
            {
               return MineCristal(blueCristal);
            }
        }
        return null;
    }

    private MinedCristal MineCristal(Cristal cristal)
    {
        _tool.SetTrigger(Mine);
        return cristal.MineIt();
    }
}
