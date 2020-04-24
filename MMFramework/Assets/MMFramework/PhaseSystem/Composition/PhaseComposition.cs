using System;
using System.Collections.Generic;
using System.Linq;

public abstract class PhaseComposition : PhaseBaseNode
{
    public List<PhaseBaseNode> ChildPhaseNodes { get; private set; }
    
    public PhaseComposition(params PhaseBaseNode[] childPhaseNodes)
    {
        ChildPhaseNodes = childPhaseNodes.ToList();
    }

    public PhaseBaseNode GetPhaseByType(Type phaseType)
    {
        return ChildPhaseNodes.FirstOrDefault(p => p.GetType().Equals(phaseType));
    }

    protected override void TraverseNode()
    {
        if (ChildPhaseNodes.Count == 0)
        {
            TraverseCompleted();

            return;
        }

        TraverseComposition();
    }

    protected abstract void TraverseComposition();

    protected bool HasAnyNotTraversedNodes()
    {
        return ChildPhaseNodes.Any(val => !val.IsTraversed);
    }

    public override void ResetNode()
    {
        ChildPhaseNodes.ForEach(p => p.ResetNode());
    }
}
