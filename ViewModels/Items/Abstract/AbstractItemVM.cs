﻿using FileManager.FileSystem;
using FileManager.Models.FileSystemItems.Interfaces;
using FileManager.Models.FileSystemItemsInformation.Interfaces;
using FileManager.ViewModels.Items.Interfaces;
using System;

namespace FileManager.ViewModels.Items.Abstract;

public abstract class AbstractItemVM : IItemVM
{
    protected readonly IFileSystemServices _fsServices;
    protected string IconSourceBase = "pack://application:,,,/Icons/";

    public IItem Item { get; init; }
    abstract public string IconSource { get; }

    abstract public  bool IsDrive { get; }
    abstract public bool IsFolder { get; }
    abstract public bool IsFile { get; }

    abstract public IInfo Info { get; }

    protected AbstractItemVM(IFileSystemServices fsServices, IItem item)
	{
        _fsServices = fsServices;
        Item = item;
	}
    protected AbstractItemVM(IFileSystemServices fsServices, string fullPath, Func<string, IFileSystemServices, IItem> itemFunction)
        : this(fsServices, itemFunction.Invoke(fullPath, fsServices))
    {
    }

    public abstract void Expand(AppVM appVM);
}
