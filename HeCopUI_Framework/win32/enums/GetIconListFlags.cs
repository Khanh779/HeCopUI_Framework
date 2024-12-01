namespace HeCopUI_Framework.Win32.Enums
{
    public enum GetIconListFlags
    {
        /// <summary>
        /// The hIcon member of the structure pointed to by the pData parameter is valid and contains an icon handle.
        /// </summary>
        GIL_ASYNC = 0x0020,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_DEFAULTICON = 0x0040,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_FORSHORTCUT = 0x0080,
        /// <summary>
        /// The hIcon member of the structure pointed to by the pData parameter is valid and contains an icon handle.
        /// </summary>
        GIL_FORSHELL = 0x0010,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_NOTFILENAME = 0x0008,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_PERINSTANCE = 0x0200,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_PERCLASS = 0x0400,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_PERFOLDER = 0x1000,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>
        GIL_OPENICON = 0x0002,
        /// <summary>
        /// The iImage member of the structure pointed to by the pData parameter is valid and contains the index of an image in the system image list.
        /// </summary>

    }
}
