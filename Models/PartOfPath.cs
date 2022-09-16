namespace FileManager.Models;

public struct PartOfPath
{
    public string FullPath { get; init; }
    public string RelevantPath { get; init; }
    public string Presentation => ToString();

    public PartOfPath(string fullPath, string relevantPath)
    {
        FullPath = fullPath;
        RelevantPath = relevantPath;
    }

    public override string ToString()
    {
        return $"{RelevantPath} >";
    }
}
