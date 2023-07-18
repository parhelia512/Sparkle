using Raylib_cs;
using Sparkle.csharp.audio;

namespace Sparkle.csharp.content.processor; 

public class SoundProcessor : IContentProcessor {
    
    public object Load(string path) {
        return AudioPlayer.LoadSound(path);
    }

    public void Unload(object content) {
        AudioPlayer.UnloadSound((Sound) content);
    }
}