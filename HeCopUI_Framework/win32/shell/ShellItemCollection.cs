using System;
using System.Collections;

namespace HeCopUI_Framework.Win32
{
    internal class ShellItemCollection : IEnumerable
    {
    	private ArrayList items;

    	private ShellItem shellItem;

    	public ShellItem ShellItem => shellItem;

    	public int Count => items.Count;

    	internal int Capacity
    	{
    		get
    		{
    			return items.Capacity;
    		}
    		set
    		{
    			items.Capacity = value;
    		}
    	}

    	public bool IsFixedSize => items.IsFixedSize;

    	public bool IsReadOnly => items.IsReadOnly;

    	public ShellItem this[int index]
    	{
    		get
    		{
    			try
    			{
    				return (ShellItem)items[index];
    			}
    			catch (ArgumentOutOfRangeException)
    			{
    				return null;
    			}
    		}
    		set
    		{
    			items[index] = value;
    		}
    	}

    	public ShellItem this[string name]
    	{
    		get
    		{
    			int index;
    			if ((index = IndexOf(name)) > -1)
    			{
    				return (ShellItem)items[index];
    			}
    			return null;
    		}
    		set
    		{
    			int index;
    			if ((index = IndexOf(name)) > -1)
    			{
    				items[index] = value;
    			}
    		}
    	}

    	public ShellItem this[IntPtr pidl]
    	{
    		get
    		{
    			int index;
    			if ((index = IndexOf(pidl)) > -1)
    			{
    				return (ShellItem)items[index];
    			}
    			return null;
    		}
    		set
    		{
    			int index;
    			if ((index = IndexOf(pidl)) > -1)
    			{
    				items[index] = value;
    			}
    		}
    	}

    	public ShellItemCollection(ShellItem shellItem)
    	{
    		this.shellItem = shellItem;
    		items = new ArrayList();
    	}

    	public void Sort()
    	{
    		items.Sort();
    	}

    	internal int Add(ShellItem value)
    	{
    		return items.Add(value);
    	}

    	internal void Clear()
    	{
    		items.Clear();
    	}

    	public bool Contains(ShellItem value)
    	{
    		return items.Contains(value);
    	}

    	public bool Contains(string name)
    	{
    		IEnumerator enumerator = GetEnumerator();
    		try
    		{
    			while (enumerator.MoveNext())
    			{
    				ShellItem shellItem = (ShellItem)enumerator.Current;
    				if (string.Compare(shellItem.Text, name, ignoreCase: true) == 0)
    				{
    					return true;
    				}
    			}
    		}
    		finally
    		{
    			IDisposable disposable = enumerator as IDisposable;
    			if (disposable != null)
    			{
    				disposable.Dispose();
    			}
    		}
    		return false;
    	}

    	public bool Contains(IntPtr pidl)
    	{
    		IEnumerator enumerator = GetEnumerator();
    		try
    		{
    			while (enumerator.MoveNext())
    			{
    				ShellItem shellItem = (ShellItem)enumerator.Current;
    				if (shellItem.PIDLRel.Equals(pidl))
    				{
    					return true;
    				}
    			}
    		}
    		finally
    		{
    			IDisposable disposable = enumerator as IDisposable;
    			if (disposable != null)
    			{
    				disposable.Dispose();
    			}
    		}
    		return false;
    	}

    	public int IndexOf(ShellItem value)
    	{
    		return items.IndexOf(value);
    	}

    	public int IndexOf(string name)
    	{
    		for (int i = 0; i < items.Count; i++)
    		{
    			if (string.Compare(this[i].Text, name, ignoreCase: true) == 0)
    			{
    				return i;
    			}
    		}
    		return -1;
    	}

    	public int IndexOf(IntPtr pidl)
    	{
    		for (int i = 0; i < items.Count; i++)
    		{
    			if (this[i].PIDLRel.Equals(pidl))
    			{
    				return i;
    			}
    		}
    		return -1;
    	}

    	internal void Insert(int index, ShellItem value)
    	{
    		items.Insert(index, value);
    	}

    	internal void Remove(ShellItem value)
    	{
    		items.Remove(value);
    	}

    	internal void Remove(string name)
    	{
    		int index;
    		if ((index = IndexOf(name)) > -1)
    		{
    			RemoveAt(index);
    		}
    	}

    	internal void RemoveAt(int index)
    	{
    		items.RemoveAt(index);
    	}

    	public IEnumerator GetEnumerator()
    	{
    		return items.GetEnumerator();
    	}
    }
}
