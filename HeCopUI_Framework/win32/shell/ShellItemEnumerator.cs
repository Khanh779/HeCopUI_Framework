using System.Collections;

namespace HeCopUI_Framework.Win32
{
    public class ShellItemEnumerator : IEnumerator
    {
    	private ShellItem parent;

    	private int index;

    	public object Current => parent[index];

    	public ShellItemEnumerator(ShellItem parent)
    	{
    		this.parent = parent;
    		index = -1;
    	}

    	public bool MoveNext()
    	{
    		index++;
    		return index < parent.Count;
    	}

    	public void Reset()
    	{
    		index = -1;
    	}
    }
}
