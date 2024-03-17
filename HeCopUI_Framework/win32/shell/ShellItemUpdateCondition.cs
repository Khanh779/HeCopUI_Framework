namespace HeCopUI_Framework.Win32
{
    internal class ShellItemUpdateCondition
    {
    	private bool continueUpdate;

    	public bool ContinueUpdate
    	{
    		get
    		{
    			return continueUpdate;
    		}
    		set
    		{
    			continueUpdate = value;
    		}
    	}

    	public ShellItemUpdateCondition()
    	{
    		continueUpdate = true;
    	}
    }
}
