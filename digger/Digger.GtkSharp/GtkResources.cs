using System.IO;
using Gdk;

namespace Digger.GtkSharp
{
    internal static class GtkResources
    {
        public static Pixbuf LoadImage(Stream stream) => new Pixbuf(stream);
    }
}