using System;

namespace HeCopUI_Framework.Win32
{
    internal class ShellItemUpdateEventArgs : EventArgs
    {
    	private ShellItem oldItem;

    	private ShellItem newItem;

    	private ShellItemUpdateType type;

    	public ShellItem OldItem => oldItem;

    	public ShellItem NewItem => newItem;

    	public ShellItemUpdateType UpdateType => type;

    	public ShellItemUpdateEventArgs(ShellItem oldItem, ShellItem newItem, ShellItemUpdateType type)
    	{
    		this.oldItem = oldItem;
    		this.newItem = newItem;
    		this.type = type;
    	}
    }
}
