using Game_Architecture.DataProccess;

namespace Game_Architecture.DataProccess;
public class Data
{
    public string Type { get; set; }
    public dynamic Content { get; set; }
}

public abstract class DataProcessor
{
    public abstract void ProcessData(Data data);
}

public class TextDataProcessor : DataProcessor
{
    public override void ProcessData(Data data)
    {
        var textContent = data.Content as TextContent;
        int wordCount = textContent.Text.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        textContent.WordCount = wordCount;
        Database.SaveTextData(textContent);
    }
}

public class AudioDataProcessor : DataProcessor
{
    public override void ProcessData(Data data)
    {
        var audioContent = data.Content as AudioContent;
        string transcription = AudioTranscriber.Transcribe(audioContent.AudioStream);
        audioContent.Transcription = transcription;
        Database.SaveAudioData(audioContent);
    }
}

public class VideoDataProcessor : DataProcessor
{
    public override void ProcessData(Data data)
    {
        var videoContent = data.Content as VideoContent;
        List<Frame> keyFrames = VideoAnalyzer.ExtractKeyFrames(videoContent.VideoStream);
        videoContent.KeyFrames = keyFrames;
        Database.SaveVideoData(videoContent);
    }
}

public class TextContent
{
    public string Text { get; set; }
    public int WordCount { get; set; }
}

public class AudioContent
{
    public Stream AudioStream { get; set; }
    public string Transcription { get; set; }
}

public class VideoContent
{
    public Stream VideoStream { get; set; }
    public List<Frame> KeyFrames { get; set; }
}

public class DataProcessorCreator
{
    private DataProcessor _processor;

    public void SetProcessor(DataProcessor processor)
    {
        _processor = processor;
    }

    public void ProcessData(Data data)
    {
        _processor.ProcessData(data);
    }
}
public class Checker
{
    public static void Main()
    {
        DataProcessorCreator creator = new DataProcessorCreator();
        creator = new DataProcessorCreator();
        creator.SetProcessor(new TextDataProcessor());
        creator.ProcessData(new Data { Type = "Text", Content = new TextContent { Text = "Hello, World!" } });
    }
}
// Database class for storing processed data (pseudo-code)
public static class Database
{
    public static void SaveTextData(TextContent content) { /* ... */ }
    public static void SaveAudioData(AudioContent content) { /* ... */ }
    public static void SaveVideoData(VideoContent content) { /* ... */ }
}

// Helper classes for audio and video processing (pseudo-code)
public static class AudioTranscriber
{
    public static string Transcribe(Stream audioStream) { /* ... */ }
}

public static class VideoAnalyzer
{
    public static List<Frame> ExtractKeyFrames(Stream videoStream) { /* ... */ }
}

// Frame class used in video processing (pseudo-code)
public class Frame { /* ... */ }
