// Decompiled with JetBrains decompiler
// Type: diao.Properties.Resources
// Assembly: diao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9B9CD16-F024-45F9-8D13-D1172328D6F7
// Assembly location: F:\engraver\LaserEngraver\Laser Framework4.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace diao.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) diao.Properties.Resources.resourceMan, (object) null))
          diao.Properties.Resources.resourceMan = new ResourceManager("diao.Properties.Resources", typeof (diao.Properties.Resources).Assembly);
        return diao.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => diao.Properties.Resources.resourceCulture;
      set => diao.Properties.Resources.resourceCulture = value;
    }
  }
}
