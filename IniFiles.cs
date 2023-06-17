// Decompiled with JetBrains decompiler
// Type: diao.IniFiles
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace diao
{
  public class IniFiles
  {
    public string inipath;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(
      string section,
      string key,
      string val,
      string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(
      string section,
      string key,
      string def,
      StringBuilder retVal,
      int size,
      string filePath);

    public IniFiles(string INIPath) => this.inipath = INIPath;

    public IniFiles()
    {
    }

    public void IniWriteValue(string Section, string Key, string Value) => IniFiles.WritePrivateProfileString(Section, Key, Value, this.inipath);

    public string IniReadValue(string Section, string Key)
    {
      StringBuilder retVal = new StringBuilder(500);
      IniFiles.GetPrivateProfileString(Section, Key, "", retVal, 500, this.inipath);
      return retVal.ToString();
    }

    public bool ExistINIFile() => File.Exists(this.inipath);
  }
}
